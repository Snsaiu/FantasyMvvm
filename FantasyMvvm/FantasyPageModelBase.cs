using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FantasyMvvm.FantasyModels;
namespace FantasyMvvm
{
    using FantasyMvvm.FantasyLocator;
    using FantasyMvvm.FantasyPageRegist;

    using Microsoft.Maui.Controls;
    using Microsoft.Maui.Controls.Internals;

    public abstract class FantasyPageModelBase : ObservableRecipient
    {




        public FantasyPageModelBase()
        {
            this.IsActive = true;
      
        }


    
    }
}
