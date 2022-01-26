using System;
using JetBrains.Annotations;
using Slackhead.ReactiveProperties;
using UnityEngine;

namespace Slackhead.MVVM
{
    public class BindingSet<TView, TViewModel> where TView : UIView where TViewModel : ViewModel
    {
        private readonly TView view;
        private readonly TViewModel viewModel;


        public BindingSet(TView view, TViewModel viewModel)
        {
            this.view = view;
            this.viewModel = viewModel;
        }


        public BindingBuilder<TViewElement, TViewModel> Bind<TViewElement>(TViewElement target)
        {
            var builder = new BindingBuilder<TViewElement, TViewModel>(target);
            return builder;
        }
    }


    public class BindingBuilder<TElement1, TElement2>
    {
        public enum BindingType
        {
            UpdateModel,
            UpdateView,
            UpdateModelAndView
        }

        private BindingType bindingType;
        private Func<TElement2, object> toFunc;
        private Func<TElement1, object> forFunc;


        [PublicAPI]
        public BindingBuilder(object target)
        {
            bindingType = BindingType.UpdateModelAndView;
        }

        
        [PublicAPI]
        public BindingBuilder<TElement1, TElement2> For(Func<TElement1, object> forFunc)
        {
            this.forFunc = forFunc;
            return this;
        }

        [PublicAPI]
        public BindingBuilder<TElement1, TElement2> To(Func<TElement2, object> toFunc)
        {
            this.toFunc = toFunc;
            return this;
        }

        [PublicAPI]
        public BindingBuilder<TElement1, TElement2> OneWay(BindingType bindingType)
        {
            this.bindingType = bindingType;
            return this;
        }
    }
}