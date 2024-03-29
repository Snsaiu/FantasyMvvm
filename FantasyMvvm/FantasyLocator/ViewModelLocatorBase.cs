﻿using FantasyMvvm.FantasyModels;
using FantasyMvvm.FantasyViewRegister;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyMvvm.FantasyLocator
{
    public abstract class ViewModelLocatorBase
    {
        private readonly IViewRegister viewRegister;

        public ViewModelLocatorBase(IViewRegister viewRegister)
        {
            this.viewRegister = viewRegister;
        }

        public ViewModelElement GetViewModelElementByName(string name)
        {
            var v=this.viewRegister.GetViewModelByName(name);
            if (v!=null)
            {
                ViewModelElement element = this.Parse(v);
                return element;
            }
            throw new NullReferenceException($"{name}未发现可注册的视图，请检查是否已经注册!");
        }

        protected abstract ViewModelElement Parse(ViewModel viewModel);
  
    }
}
