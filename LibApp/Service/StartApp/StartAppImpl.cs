﻿using LibApp.Service.Documento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Service.StartApp {
    public class StartAppImpl : IStartApp {

        private static IDocumento DocumentoService = ServiceLab.GetInstanceOf<DocumentoImpl>();
        const string DIRECTORY_NAME = @"C:\assessment_carlos_henrique";
        const string FILE_DB_NAME = "db_file_name_carlos_henrique.txt";

        void IStartApp.start() {
            CriaDiretorioPrincipal();
            criaArquivoPrincipal();
        }

        // deve chamar o serviço e criar o diretorio;
        private void CriaDiretorioPrincipal() {
            while (!DocumentoService.HaveDirectory(DIRECTORY_NAME)) {
                DocumentoService.CreateDirectory(DIRECTORY_NAME);
            }
        }

        // deve chamar o serviço e criar o arquivo principal
        private void criaArquivoPrincipal() {
            while (!DocumentoService.HavePrincipalFile(DIRECTORY_NAME, FILE_DB_NAME)) {
                DocumentoService.CreatePrincipalFile(DIRECTORY_NAME, FILE_DB_NAME);
            }
        }
    }
}