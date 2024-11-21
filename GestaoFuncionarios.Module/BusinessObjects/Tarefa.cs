using System.Collections.ObjectModel;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using MySolution.Module.BusinessObjects;

namespace GestaoFuncionarios.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ModelDefault("Caption", "Tarefas")]
    public class Tarefa : BaseObject
    {
        public virtual DateTime? DataFinalizacao { get; set; }
        public virtual String Assunto { get; set; }

        [FieldSize(FieldSizeAttribute.Unlimited)]
        public virtual String Descricao { get; set; }
        public virtual DateTime? DataVencimento { get; set; }
        public virtual DateTime? DataInicio { get; set; }
        public virtual int PercentualConclusao { get; set; }

        public virtual PrioridadeEnum Prioridade { get; set; }

        private StatusTarefa _status;
        public virtual StatusTarefa Status
        {
            get { return _status; }
            set
            {
                _status = value;

                DataFinalizacao = (value == StatusTarefa.Concluido) ? DateTime.Now : null;
            }
        }


        public enum StatusTarefa
        {
            [ImageName("State_Task_NotStarted")]
            NaoIniciado,
            [ImageName("State_Task_InProgress")]
            EmAndamento,
            [ImageName("State_Task_WaitingForSomeoneElse")]
            Pendente,
            [ImageName("State_Task_Deferred")]
            Adiado,
            [ImageName("State_Task_Completed")]
            Concluido
        }

        public enum PrioridadeEnum
        {
            Baixa,
            Normal,
            Alta
        }

        public virtual IList<Funcionario> Funcionarios { get; set; } = new ObservableCollection<Funcionario>();


        public override void OnCreated()
        {
            base.OnCreated();
            Prioridade = PrioridadeEnum.Normal;
        }

    }
}
