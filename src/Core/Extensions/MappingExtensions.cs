﻿using AutoMapper;
using System;
using System.Linq.Expressions;

namespace EnduranceJudge.Core.Extensions
{
    public static class MappingExtensions
    {
        public static IMappingExpression<TSource, TDestination> MapMember<TSource, TDestination, T>(
            this IMappingExpression<TSource, TDestination> mapping,
            Expression<Func<TDestination, T>> destinationMemberSelector,
            Expression<Func<TSource, T>> sourceMemberSelector)
        {
            return mapping.ForMember(destinationMemberSelector, opt => opt.MapFrom(sourceMemberSelector));
        }
    }
}
