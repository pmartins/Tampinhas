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
        [StringLength(150)]
        [DisplayName("Nome da Pessoa a Beneficiar")]
        public string BenefiterName { get; set; }

        [StringLength(500)]
        [DisplayName("Descrição do Projecto")]
        public string Description { get; set; }

        [DisplayName("Nome da Organização")]
        public virtual Organization Organization { get; set; }

        [StringLength(150)]
        [DisplayName("Pessoa Responsável")]
        public string ResponsibleName { get; set; }

        [DisplayName("Quantidade de cápsulas a angariar (Kgs)")]
        public int TotalAmmountRaise { get; set; }
    }

    [MetadataType(typeof(OrganizationMeta))]
    public partial class Organization
    {

    }

    public class OrganizationMeta 
    {
        [DisplayName("Nome da Organização")]
        public string Name { get; set; }

        [DisplayName("Morada")]
        public string Address { get; set; }

        [DisplayName("Localidade")]
        public string Location { get; set; }

        [DisplayName("Concelho")]
        public Place County { get; set; }

        [DisplayName("Distrito")]
        public Place District { get; set; }

    }


}