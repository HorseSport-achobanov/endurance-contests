﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace EnduranceJudge.Gateways.Desktop.Core
{
    public class ViewModelBase : BindableBase, INavigationAware
    {
        protected IRegionNavigationJournal journal;

        public DelegateCommand NavigateForward => new DelegateCommand(() => this.journal?.GoForward());
        public DelegateCommand NavigateBack => new DelegateCommand(() => this.journal?.GoBack());

        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.journal = navigationContext.NavigationService.Journal;
        }

        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
            => true;

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}