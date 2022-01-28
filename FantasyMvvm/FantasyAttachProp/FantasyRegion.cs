using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyMvvm.FantasyAttachProp
{
    public class FantasyRegion
    {

        
        public static readonly BindableProperty RegionProperty =
            BindableProperty.CreateAttached(
                propertyName: "Region",
                    returnType: typeof(string),
                    declaringType: typeof(string),
                null,
                BindingMode.TwoWay,
                propertyChanged: ViewChanged
                );

        public static string GetRegion(BindableObject bindable)
        {
            return (string)bindable.GetValue(RegionProperty);
        }
        public static void SetRegion(BindableObject bindable, string value)
        {
            bindable.SetValue(RegionProperty, value);
        }
       
        private static void ViewChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (string.IsNullOrEmpty(newvalue.ToString()))
            {
                throw new ArgumentNullException($"注册试图的key是空的");
            }
           var regionLocator=  FantasyContainer.GetRequiredService<FantasyRegionLocator.RegionLocatorBase>();
            regionLocator.Add(newvalue.ToString(), bindable as ContentView);
        }
    }
}
