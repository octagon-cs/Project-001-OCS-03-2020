using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace won.Views.Progress
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NodeView : ContentView
    {
        public NodeView(Models.ProgressNode progressNode)
        {
            InitializeComponent();

            node.BackgroundColor = progressNode.ColorStatus;
            horizontal.BackgroundColor = progressNode.ColorStatus;
            created.TextColor= progressNode.ColorStatus;
            role.TextColor= progressNode.ColorStatus;
            stats.TextColor= progressNode.ColorStatus;
            message.TextColor= progressNode.ColorStatus;

            if (progressNode.Status == StatusPersetujuan.None)
            {
                created.IsVisible = false;
                stats.IsVisible = false;
                progressNode.Message = "Selanjutnya";
            }


            if (string.IsNullOrEmpty(progressNode.Message))
                message.IsVisible = false;

            if (progressNode.Position== PositionNode.Start)
            {
                vertical.Margin = new Thickness(0, 10, 0, 0);
            }

            if(progressNode.Position== PositionNode.End)
            {
                vertical.VerticalOptions = LayoutOptions.Start;

            }

            BindingContext = progressNode;

        }
    }
}