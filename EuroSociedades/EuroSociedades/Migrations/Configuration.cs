namespace EuroSociedades.Migrations
{
    using EuroSociedades.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EurosociDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //ContextKey = "EuroSociedades.Models.EurosociDB";
        }

        protected override void Seed(EurosociDB context)
        {
            //*************************************
            // adiciona JOGADORES
            var jogadores = new List<Jogadores> {
               new Jogadores {ID=1, Nome="Rui Freitas", Username="rufino", Email="rufino@gmail.com",  DataNascimento=new DateTime(1968,2,20) },
               new Jogadores {ID=2, Nome="António Rocha", Username="antonio1981", Email="AntonioRocha@hotmail.com",  DataNascimento=new DateTime(1981,7,2) },
               new Jogadores {ID=3, Nome="André Silveira", Username="a.Silveira", Email="andre_Silv@iol.com",  DataNascimento=new DateTime(1977,1,31) },
               new Jogadores {ID=4, Nome="Maria Teixeira", Username="maritei", Email="mariazinha@gmail.com",  DataNascimento=new DateTime(1980,6,15) },
               new Jogadores {ID=5, Nome="Clara Pinto", Username="clarinha", Email="clara1990@gmail.com",  DataNascimento=new DateTime(1990,1,24) },
               new Jogadores {ID=6, Nome="Rui Ferreira", Username="rui_ferreira", Email="rui_ferreira@yahoo.com",  DataNascimento=new DateTime(1981,9,11) },
               new Jogadores {ID=7, Nome="Fábio Ribeiro", Username="tuning", Email="fabituning92@gmail.com",  DataNascimento=new DateTime(1992,12,29) },
               new Jogadores {ID=8, Nome="Augusto Sousa", Username="guguMiCa", Email="AugustoSousa@outlook.pt",  DataNascimento=new DateTime(1974,2,6) },
               new Jogadores {ID=9, Nome="Beatriz Pinto", Username="minorca23", Email="minorca23@iol.com",  DataNascimento=new DateTime(1983,8,19) },
               new Jogadores {ID=10, Nome="José Alves", Username="jomasal", Email="Jose_alves76@yahoo.com",  DataNascimento=new DateTime(1976,5,3) },
            };
            jogadores.ForEach(jj => context.Jogadores.AddOrUpdate(j => j.Nome, jj));
            context.SaveChanges();

            //***************************************
            // adiciona SOCIEDADES
            var sociedades = new List<Sociedades> {
               new Sociedades {ID=1, Nome="Euromilhas", GestorFK=1, DataConstituicao=new DateTime(2017,8,20) },
               new Sociedades {ID=2, Nome="Ricos e famosos", GestorFK=2, DataConstituicao=new DateTime(2018,1,1) },
               new Sociedades {ID=3, Nome="Azarados", GestorFK=5, DataConstituicao=new DateTime(2018,2,28) },
            };
            sociedades.ForEach(ss => context.Sociedades.AddOrUpdate(s => s.Nome, ss));
            context.SaveChanges();

            // adiciona SÓCIOS
            var socios = new List<Jog_Soc> {
             new Jog_Soc {ID=1, JogadorFK=1, SociedadeFK=1,  DataEntrada=new DateTime(2017,8,21)},
             new Jog_Soc {ID=2, JogadorFK=2, SociedadeFK=2,  DataEntrada=new DateTime(2017,2,23)},
             new Jog_Soc {ID=3, JogadorFK=3, SociedadeFK=1,  DataEntrada=new DateTime(2017,10,21), DataSaida=new DateTime(2017,12,31)},
             new Jog_Soc {ID=4, JogadorFK=4, SociedadeFK=1,  DataEntrada=new DateTime(2018,3,1)},
             new Jog_Soc {ID=5, JogadorFK=5, SociedadeFK=3,  DataEntrada=new DateTime(2018,1,24)},
             new Jog_Soc {ID=6, JogadorFK=6, SociedadeFK=2,  DataEntrada=new DateTime(2018,1,29)},
             new Jog_Soc {ID=7, JogadorFK=8, SociedadeFK=2,  DataEntrada=new DateTime(2018,2,6)},
             new Jog_Soc {ID=8, JogadorFK=7, SociedadeFK=1,  DataEntrada=new DateTime(2018,2,19)},
             new Jog_Soc {ID=9, JogadorFK=10, SociedadeFK=3,  DataEntrada=new DateTime(2018,2,3)},
            };
            socios.ForEach(ss => context.Jog_Socs.AddOrUpdate(s => new { s.JogadorFK, s.SociedadeFK }, ss));
            context.SaveChanges();

            // adiciona PAGAMENTOS
            var pagamentos = new List<Pagamentos> {
               new Pagamentos {ID=1, Jog_SocFK=1, ValorPago=5,  DataPagamento=new DateTime(2017,8,21) },
               new Pagamentos {ID=2, Jog_SocFK=2, ValorPago=3,  DataPagamento=new DateTime(2017,2,23) },
               new Pagamentos {ID=3, Jog_SocFK=4, ValorPago=10,  DataPagamento=new DateTime(2017,10,21) },
               new Pagamentos {ID=4, Jog_SocFK=5, ValorPago=4,  DataPagamento=new DateTime(2018,3,1) },
               new Pagamentos {ID=5, Jog_SocFK=3, ValorPago=5,  DataPagamento=new DateTime(2018,1,24) },
               new Pagamentos {ID=6, Jog_SocFK=1, ValorPago=12,  DataPagamento=new DateTime(2018,3,11) },
               new Pagamentos {ID=7, Jog_SocFK=6, ValorPago=4,  DataPagamento=new DateTime(2018,1,29) },
               new Pagamentos {ID=8, Jog_SocFK=7, ValorPago=10,  DataPagamento=new DateTime(2018,2,6) },
               new Pagamentos {ID=9, Jog_SocFK=9, ValorPago=5,  DataPagamento=new DateTime(2018,2,19) },
            };
            pagamentos.ForEach(pp => context.Pagamentos.AddOrUpdate(p => p.ID, pp));
            context.SaveChanges();

            // adiciona TIPOS DE CHAVES
            var tipochaves = new List<TipoChaves> {
               new TipoChaves {ID=1, Tipo="Chave Apostada" },
               new TipoChaves {ID=2, Tipo="Chave Sorteio" },
            };
            tipochaves.ForEach(tt => context.TipoChaves.AddOrUpdate(t => t.Tipo, tt));
            context.SaveChanges();

            // adiciona CHAVES
            var chaves = new List<Chaves> {
                new Chaves { ID = 1, Preco = null, TipoChaveFK = 2, Numeros = "12 17 28 35 47", Estrelas = "7 11" },
                new Chaves { ID = 2, Preco = null, TipoChaveFK = 2, Numeros = "3 8 16 40 43", Estrelas = "5 8" },
                new Chaves { ID = 3, Preco = null, TipoChaveFK = 2, Numeros = "1 29 33 45 47", Estrelas = "4 8" },
                new Chaves { ID = 4, Preco = null, TipoChaveFK = 2, Numeros = "14 27 39 46 48", Estrelas = "11 12" },
                new Chaves { ID = 5, Preco = null, TipoChaveFK = 2, Numeros = "5 25 34 48 50", Estrelas = "6 7" },
                new Chaves { ID = 6, Preco = null, TipoChaveFK = 2, Numeros = "15 27 33 39 50", Estrelas = "4 6" },
                new Chaves { ID = 7, Preco = null, TipoChaveFK = 2, Numeros = "3 16 25 39 44", Estrelas = "7 11" },
                new Chaves { ID = 8, Preco = null, TipoChaveFK = 2, Numeros = "20 23 28 30 44 ", Estrelas = "3 7" },
                new Chaves { ID = 9, Preco = 2.5M, TipoChaveFK = 1, Numeros = "3 6 12 13 25 41", Estrelas = "1 2" },
                new Chaves { ID = 10, Preco = 2.5M, TipoChaveFK = 1, Numeros = "5 16 23 30 49", Estrelas = "6 7" },
                new Chaves { ID = 11, Preco = 2.5M, TipoChaveFK = 1, Numeros = "3 15 29 35 47", Estrelas = "3 4" },
                new Chaves { ID = 12, Preco = 2.5M, TipoChaveFK = 1, Numeros = "3 27 29 33 50", Estrelas = "2 7" },
                new Chaves { ID = 13, Preco = 2.5M, TipoChaveFK = 1, Numeros = "6 9 19 26 31", Estrelas = "11 12" },
                new Chaves { ID = 14, Preco = 2.5M, TipoChaveFK = 1, Numeros = "5 12 20 26 48", Estrelas = "2 11" },
            };
            chaves.ForEach(cc => context.Chaves.AddOrUpdate(c => c.ID, cc));
            context.SaveChanges();

            //adiciona CONCURSOS
            var concursos = new List<Concursos> {
                new Concursos { ID = 1, NomeConcurso="26/2018", ChaveFK=1,  DataConcurso=new DateTime(2018,3,30)},
                new Concursos { ID = 2, NomeConcurso = "27/2018", ChaveFK = 2, DataConcurso = new DateTime(2018, 4, 3) },
                new Concursos { ID = 3, NomeConcurso = "28/2018", ChaveFK = 3, DataConcurso = new DateTime(2018, 4, 6) },
                new Concursos { ID = 4, NomeConcurso = "29/2018", ChaveFK = 4, DataConcurso = new DateTime(2018, 4, 10) },
                new Concursos { ID = 5, NomeConcurso = "30/2018", ChaveFK = 5, DataConcurso = new DateTime(2018, 4, 13) },
                new Concursos { ID = 6, NomeConcurso = "31/2018", ChaveFK = 6, DataConcurso = new DateTime(2018, 4, 17) },
                new Concursos { ID = 7, NomeConcurso = "32/2018", ChaveFK = 7, DataConcurso = new DateTime(2018, 4, 20) },
                new Concursos { ID = 8, NomeConcurso = "33/2018", ChaveFK = 8, DataConcurso = new DateTime(2018, 4, 24) },
                new Concursos { ID = 9, NomeConcurso = "34/2018", ChaveFK = null, DataConcurso = new DateTime(2018, 4, 27) },
                new Concursos { ID = 10, NomeConcurso = "35/2018", ChaveFK = null, DataConcurso = new DateTime(2018, 5, 1) },
                new Concursos { ID = 11, NomeConcurso = "36/2018", ChaveFK = null, DataConcurso = new DateTime(2018, 5, 4) },
                new Concursos { ID = 12, NomeConcurso = "37/2018", ChaveFK = null, DataConcurso = new DateTime(2018, 5, 8) },
                new Concursos { ID = 13, NomeConcurso = "38/2018", ChaveFK = null, DataConcurso = new DateTime(2018, 5, 11) },
                new Concursos { ID = 14, NomeConcurso = "39/2018", ChaveFK = null, DataConcurso = new DateTime(2018, 5, 15) },
                new Concursos { ID = 15, NomeConcurso = "40/2018", ChaveFK = null, DataConcurso = new DateTime(2018, 5, 18) },
                new Concursos { ID = 16, NomeConcurso = "41/2018", ChaveFK = null, DataConcurso = new DateTime(2018, 5, 22) },
            };
            concursos.ForEach(cc => context.Concursos.AddOrUpdate(c => c.NomeConcurso, cc));
            context.SaveChanges();


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
