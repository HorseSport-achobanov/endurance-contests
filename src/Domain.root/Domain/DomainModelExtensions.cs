using EnduranceContestManager.Domain.Core.Validation;
using System;
using System.Collections.Generic;

namespace EnduranceContestManager.Domain
{
    internal static class DomainModelExtensions
    {
        internal static void Add<TPrincipal, TDependant>(
            this TPrincipal principal,
            Func<TPrincipal, List<TDependant>> collectionSelector,
            TDependant dependant)
            where TPrincipal : IInternalDomainModel
            where TDependant : class, IDependsOn<TPrincipal>
        {
            principal.Except(() =>
            {
                collectionSelector(principal).CheckExistingAndAdd(dependant);
                dependant.Set(principal);
            });
        }

        internal static void Remove<TPrincipal, TDependant>(
            this TPrincipal principal,
            Func<TPrincipal, List<TDependant>> collectionSelector,
            TDependant dependant)
            where TPrincipal : IInternalDomainModel
            where TDependant : class, IDependsOn<TPrincipal>
        {
            principal.Except(() =>
            {
                collectionSelector(principal).CheckNotExistingAndRemove(dependant);
                dependant.Clear(principal);
            });
        }

        internal static void Set<TPrincipal, TDependant>(
            this TPrincipal principal,
            Func<TPrincipal, TDependant> selector,
            Action<TPrincipal, TDependant> assigner,
            TDependant dependant)
            where TPrincipal : IInternalDomainModel
            where TDependant : class, IDependsOn<TPrincipal>
        {
            principal.Except(() =>
            {
                var existing = selector(principal);
                existing?.Clear(principal);

                assigner(principal, dependant);
                dependant.Set(principal);
            });
        }

        internal static void Clear<TPrincipal, TDependant>(
            this TPrincipal principal,
            Func<TPrincipal, TDependant> selector,
            Action<TPrincipal, TDependant> assigner)
            where TPrincipal : IInternalDomainModel
            where TDependant : class, IDependsOn<TPrincipal>
        {
            principal.Except(() =>
            {
                var existingDependant = selector(principal);
                if (existingDependant != null)
                {
                    existingDependant.Clear(principal);
                    assigner(principal, null);
                }
            });
        }

    }
}