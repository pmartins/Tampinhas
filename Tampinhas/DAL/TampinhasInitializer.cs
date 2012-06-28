using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using Tampinhas.Models;

namespace Tampinhas.DAL
{
    public class TampinhasInitializer : IDatabaseInitializer<TampinhasEntities> //: DropCreateDatabaseIfModelChanges<TampinhasEntities>
    {
        private void RemoveDatabaseData(TampinhasEntities context)
        {
            // Remove All Data           
            context.Database.ExecuteSqlCommand("DELETE FROM ProjectSet");
            context.Database.ExecuteSqlCommand("DELETE FROM StatusTypeSet");
            context.Database.ExecuteSqlCommand("DELETE FROM UserSet");
            context.Database.ExecuteSqlCommand("DELETE FROM OrganizationSet");
            context.Database.ExecuteSqlCommand("DELETE FROM PlaceSet");
            
            // Reseed all tables                        
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT (StatusTypeSet, RESEED, 0)");
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT (UserSet, RESEED, 0)");
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT (ProjectSet, RESEED, 0)");
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT (PlaceSet, RESEED, 0)");
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT (OrganizationSet, RESEED, 0)");

        }
        public void InitializeDatabase(TampinhasEntities context)
        {
            RemoveDatabaseData(context);
            Seed(context);
        }
        
        protected void Seed(TampinhasEntities context)
        {
            var places = new List<Place>
            {
                // Distritos
                new Place { Id = 1, Name = "Aveiro" },
                new Place { Id = 2, Name = "Beja" },
                new Place { Id = 3, Name = "Braga" },
                new Place { Id = 4, Name = "Bragança" },
                new Place { Id = 5, Name = "Castelo Branco" },
                new Place { Id = 6, Name = "Coimbra" },
                new Place { Id = 7, Name = "Évora" },
                new Place { Id = 8, Name = "Faro" },
                new Place { Id = 9, Name = "Guarda" },
                new Place { Id = 10, Name = "Leiria" },
                new Place { Id = 11, Name = "Lisboa" },
                new Place { Id = 12, Name = "Portalegre" },
                new Place { Id = 13, Name = "Porto" },
                new Place { Id = 14, Name = "Santarém" },
                new Place { Id = 15, Name = "Setúbal" },
                new Place { Id = 16, Name = "Viana do Castelo" },
                new Place { Id = 17, Name = "Vila Real" },
                new Place { Id = 18, Name = "Viseu" },

                // Concelhos
                // Concelhos de Aveiro
                new Place { Id = 19, Name="Águeda", ParentId=1 },
                new Place { Id = 20, Name="Albergaria-a-Velha", ParentId=1 },
                new Place { Id = 21, Name="Anadia", ParentId=1 },
                new Place { Id = 22, Name="Arouca", ParentId=1 },
                new Place { Id = 23, Name="Aveiro", ParentId=1 },
                new Place { Id = 24, Name="Castelo de Paiva", ParentId=1 },
                new Place { Id = 25, Name="Espinho", ParentId=1 },
                new Place { Id = 26, Name="Estarreja", ParentId=1 },
                new Place { Id = 27, Name="Ílhavo", ParentId=1 },
                new Place { Id = 28, Name="Mealhada", ParentId=1 },
                new Place { Id = 29, Name="Murtosa", ParentId=1 },
                new Place { Id = 30, Name="Oliveira de Azeméis", ParentId=1 },
                new Place { Id = 31, Name="Oliveira do Bairro", ParentId=1 },
                new Place { Id = 32, Name="Ovar", ParentId=1 },
                new Place { Id = 33, Name="Santa Maria da Feira", ParentId=1 },
                new Place { Id = 34, Name="São João da Madeira", ParentId=1 },
                new Place { Id = 35, Name="Sever do Vouga", ParentId=1 },
                new Place { Id = 36, Name="Vagos", ParentId=1 },
                new Place { Id = 37, Name="Vale de Cambra", ParentId=1 },


                // Concelhos de Lisboa
                new Place { Id = 38, Name="Alenquer", ParentId=11 },
                new Place { Id = 39, Name="Amadora", ParentId=11 },
                new Place { Id = 40, Name="Arruda dos Vinhos", ParentId=11 },
                new Place { Id = 41, Name="Azambuja", ParentId=11 },
                new Place { Id = 42, Name="Cadaval", ParentId=11 },
                new Place { Id = 43, Name="Cascais", ParentId=11 },
                new Place { Id = 44, Name="Lisboa", ParentId=11 },
                new Place { Id = 45, Name="Loures", ParentId=11 },
                new Place { Id = 46, Name="Lourinhã", ParentId=11 },
                new Place { Id = 47, Name="Mafra", ParentId=11 },
                new Place { Id = 48, Name="Odivelas", ParentId=11 },
                new Place { Id = 49, Name="Oeiras", ParentId=11 },
                new Place { Id = 50, Name="Sintra", ParentId=11 },
                new Place { Id = 51, Name="Sobral de Monte Agraço", ParentId=11 },
                new Place { Id = 52, Name="Torres Vedras", ParentId=11 },
                new Place { Id = 53, Name="Vila Franca de Xira", ParentId=11 },

                // Concelhos do Porto
                new Place { Id = 54, Name="Amarante", ParentId=13 },
                new Place { Id = 55, Name="Baião", ParentId=13 },
                new Place { Id = 56, Name="Felgueiras", ParentId=13 },
                new Place { Id = 57, Name="Gondomar", ParentId=13 },
                new Place { Id = 58, Name="Lousada", ParentId=13 },
                new Place { Id = 59, Name="Maia", ParentId=13 },
                new Place { Id = 60, Name="Marco de Canaveses", ParentId=13 },
                new Place { Id = 61, Name="Matosinhos", ParentId=13 },
                new Place { Id = 62, Name="Paços de Ferreira", ParentId=13 },
                new Place { Id = 63, Name="Paredes", ParentId=13 },
                new Place { Id = 64, Name="Penafiel", ParentId=13 },
                new Place { Id = 65, Name="Porto", ParentId=13 },
                new Place { Id = 66, Name="Póvoa de Varzim", ParentId=13 },
                new Place { Id = 67, Name="Santo Tirso", ParentId=13 },
                new Place { Id = 68, Name="Trofa", ParentId=13 },
                new Place { Id = 69, Name="Valongo", ParentId=13 },
                new Place { Id = 70, Name="Vila do Conde", ParentId=13 },
                new Place { Id = 71, Name="Vila Nova de Gaia", ParentId=13 },


                // Concelhos de Setúbal
                new Place { Id = 72, Name="Alcácer do Sal", ParentId=15 },
                new Place { Id = 73, Name="Alcochete", ParentId=15 },
                new Place { Id = 74, Name="Almada", ParentId=15 },
                new Place { Id = 75, Name="Barreiro", ParentId=15 },
                new Place { Id = 76, Name="Grândola", ParentId=15 },
                new Place { Id = 77, Name="Moita", ParentId=15 },
                new Place { Id = 78, Name="Montijo", ParentId=15 },
                new Place { Id = 79, Name="Palmela", ParentId=15 },
                new Place { Id = 80, Name="Santiago do Cacém", ParentId=15 },
                new Place { Id = 81, Name="Seixal", ParentId=15 },
                new Place { Id = 82, Name="Sesimbra", ParentId=15 },
                new Place { Id = 83, Name="Setúbal", ParentId=15 },
                new Place { Id = 84, Name="Sines", ParentId=15 }   
            };
            places.ForEach(s => context.PlaceSet.Add(s));
            context.SaveChanges();

            var organizations = new List<Organization>
            {
                new Organization { Id=1, Name = "Centro Social Padre Gameiro", Address = "Quinta do Chegadinho", DistrictId = 15, CountyId = 74, Location = "Feijó", Phone = "212212131" }
            };
            organizations.ForEach(s => context.OrganizationSet.Add(s));
            context.SaveChanges();

            var statusType = new List<StatusType>
            {
                new StatusType { Id = 1, Description="Activo" },
                new StatusType { Id = 2, Description="Cancelado" },
                new StatusType { Id = 3, Description="Terminado" }
            };
            statusType.ForEach(s => context.StatusTypeSet.Add(s));
            context.SaveChanges();

            var user = new List<User>
            {
                new User { Id = 1, Name="Zezinho", Email="zezinho@gmail.com", Active=true, Password="XXX" }
            };
            user.ForEach(s => context.UserSet.Add(s));
            context.SaveChanges();

            var projects = new List<Project>
            {
                new Project { Id = 1, OrganizationId=1, TotalAmmountRaise=5000, Description="Cadeira de rodas para o Joãozinho", ResponsibleName="Jaquim Manel", BenefiterName="Joãozinho", CreationDate=DateTime.Now, StatusTypeId=1, ModifiedDate=DateTime.Now, CreatorId = 1 }
            };
            projects.ForEach(s => context.ProjectSet.Add(s));
            context.SaveChanges();

            //base.Seed(context);
        }
    }
}