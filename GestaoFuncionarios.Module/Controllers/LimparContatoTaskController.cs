using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using MySolution.Module.BusinessObjects;

namespace GestaoFuncionarios.Module.Controllers
{
    public partial class LimparContatoTaskController : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public LimparContatoTaskController()
        {
            InitializeComponent();
            TargetViewType = ViewType.DetailView;
            TargetObjectType = typeof(Funcionario);
            
            SimpleAction clearTasksAction = new SimpleAction(this, "LimparTarefas", PredefinedCategory.View)
            {
                //Specify the Action's button caption.
                Caption = "Limpar Tarefas",
                //Specify the confirmation message that pops up when a user executes an Action.
                ConfirmationMessage = "Certeza que deseja limpar a lista de tarefas?",
                //Specify the icon of the Action's button in the interface.
                ImageName = "Action_Clear"
            };
            //This event fires when a user clicks the Simple Action control. Handle this event to execute custom code.
            clearTasksAction.Execute += ClearTasksAction_Execute;
        }
        private void ClearTasksAction_Execute(Object sender, SimpleActionExecuteEventArgs e)
        {
            while ( ( (Funcionario)View.CurrentObject).Tarefas.Count > 0)
            {
                ((Funcionario)View.CurrentObject).Tarefas.Remove(((Funcionario)View.CurrentObject).Tarefas[0]);
                ObjectSpace.SetModified(View.CurrentObject, View.ObjectTypeInfo.FindMember(nameof(Funcionario.Tarefas)));
            }
        }


        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

    }
}
