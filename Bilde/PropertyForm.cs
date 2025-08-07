using System;
using System.Windows.Forms;

namespace Bilde
{
   /// <summary>
   /// Simple form to access object properties
   /// </summary>
   /// 
   public partial class PropertyForm : Form
   {
      /// <summary>
      /// Default contructor
      /// </summary>
      public PropertyForm()
      {
         InitializeComponent();
      }

      public PropertyGrid PropertyGrid { get { return _propertyGrid; } }

      /// <summary>
      /// Pass an object to the property ghrid
      /// </summary>
      public object SelectedObject
      {
         set { _propertyGrid.SelectedObject = value; }
         get { return _propertyGrid.SelectedObject; }
      }

      /// <summary>
      /// Force sorting methode
      /// </summary>
      public PropertySort PropertySort
      {
         get { return _propertyGrid.PropertySort; }
         set { _propertyGrid.PropertySort = value; }
      }

      private void OkButton_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void _propertyGrid_Click(object sender, EventArgs e)
      {

      }
   }
}
