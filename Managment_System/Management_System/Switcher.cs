using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Data;
namespace Management_System
{
    public static class Switcher
  	{
    	public static PageSwitcher pageSwitcher;

    	public static void Switch(UserControl oldPage, UserControl newPage)
    	{
            oldPage = null; //Referencing UC to null
            GC.Collect(); //Call Garbage Collector for deleting old UserContol objects and refrences 
            pageSwitcher.Navigate(newPage);
            
    	}
        public static void Switch( UserControl newPage)
        {
            UserControl temp = newPage;
            pageSwitcher.Navigate(temp);
        }

    	public static void Switch(UserControl newPage, object state)
    	{
      		pageSwitcher.Navigate(newPage, state);
    	}
  	}
}