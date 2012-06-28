using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace Tampinhas.Models
{
    [MetadataType(typeof(ProjectMeta))]
    public partial class Project
    {
    }

    public class ProjectMeta 
    {
        [DisplayName("Nome da Pessoa a Beneficiar")]
        public string BenefiterName { get; set; }
        
        [DisplayName("Descrição do Projecto")]
        public string Description { get; set; }

        [DisplayName("Nome da Organização")]
        public virtual Organization Organization { get; set; }

        [DisplayName("Pessoa Responsável")]
        public string ResponsibleName { get; set; }

        [DisplayName("Quantidade de cápsulas a angariar (Kgs)")]
        public int TotalAmmountRaise { get; set; }


    }
}