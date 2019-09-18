﻿using LibApp.Model;
using LibApp.Service;
using LibApp.Service.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Helper {
    public class Utils {

        private static IUsuario ServiceUsuario = ServiceLab.GetInstanceOf<UsuarioImpl>();

        public static string[] SolicitarDadosLogar() {
            string[] vet = new string[2];
            Console.Clear();

            string email, senha;
            Console.WriteLine("Escreva seu email");
            email = Console.ReadLine();

            Console.WriteLine("Escreva uma senha");
            senha = Console.ReadLine();
            vet[0] = email;
            vet[1] = senha;
            return vet;
        }

        public static string[] SolicitarDadosCadastrar() {
            string[] vet = new string[5];
            Console.Clear();

            Console.WriteLine("Vamos realizar o seu cadastro!");

            string nome, sobreNome, email, data, senha;

            Console.WriteLine("Escreva seu primeiro nome");
            nome = Console.ReadLine();

            Console.WriteLine("Escreva seu sobrenome");
            sobreNome = Console.ReadLine();

            Console.WriteLine("Escreva seu email");
            email = Console.ReadLine();

            Console.WriteLine("Escreva a data de nascimento no formato YYYY/MM/DD");
            data = Console.ReadLine();

            Console.WriteLine("Escreva uma senha");
            senha = Console.ReadLine();

            vet[0] = nome;
            vet[1] = sobreNome;
            vet[2] = email;
            vet[3] = data;
            vet[4] = senha;
            Console.Clear();
            return vet;
        }

        private static void EscreverMenu() {
            Console.Clear();
            Console.WriteLine("SELECIONE UMA OPÇÃO");
            Console.WriteLine("1 - LOGAR");
            Console.WriteLine("2 - CADASTRAR");
            Console.WriteLine("3 - SAIR");
        }

        private static void EscreveMenuAutenticado() {
            Console.Clear();
            Console.WriteLine("SELECIONE UMA OPÇÃO");
            Console.WriteLine("1 - CONSULTAR AMIGO");
            Console.WriteLine("2 - CADASTRAR AMIGO");
            Console.WriteLine("3 - LISTAR AMIGOS");
            Console.WriteLine("4 - EXCLUIR AMIGO");
        }

        private static void SolicitaAcaoAutenticado(Usuario autenticado) {
            int value = int.MaxValue;

            while (value == int.MaxValue) {
                EscreveMenuAutenticado();
                value = SolicitaAcao();

                if (OpcaoSelecionadaLogadoValido(value)) {
                    ExecutaAcaoDoUsuarioLogado(value, autenticado);
                } else {
                    Console.WriteLine("Opcao invalida");
                    value = int.MaxValue;
                }
            }


            Console.ReadLine();
        }

        private static int SolicitaAcao() {
            int value = int.MaxValue;

            while (value == int.MaxValue) {
                Console.WriteLine("Digite uma opção valida");
                try {
                    value = Int32.Parse(Console.ReadLine());
                } catch (Exception e) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Valor digitado inválido");
                    Console.ResetColor();
                    value = int.MaxValue;
                }
            }
            Console.Clear();
            return value;
        }

        public static void Interacao() {
            int opcao = 0;

            while (opcao != 3) {
                EscreverMenu();
                opcao = SolicitaAcao();

                if (OpcaoSelecionadaValida(opcao)) {
                    ExecutaSelecao(opcao);
                }
            }
        }

        private static bool OpcaoSelecionadaValida(int opcao) {
            return opcao >= 1 && opcao <= 3;
        }

        private static bool OpcaoSelecionadaLogadoValido(int opcao) {
            return opcao >= 1 && opcao <= 4;
        }

        private static void ExecutaAcaoDoUsuarioLogado(int opcaoSelecionada, Usuario autenticado) {
            Console.WriteLine(opcaoSelecionada);

            switch (opcaoSelecionada) {
                
                //consultar amigo
                case 1:

                    break;
                //cadastrar amigo
                case 2:

                    break;

                default:
                    Console.WriteLine("ESTOU PERDIDO, HELP!");
                    break;
            }


            Console.ReadKey();
        }

        private static void ExecutaSelecao(int opcaoSelecionada) {
            switch (opcaoSelecionada) {

                // logar
                case 1:
                    Usuario u = ServiceUsuario.Logar(SolicitarDadosLogar());

                    if (Autenticado(u)) {
                        SolicitaAcaoAutenticado(u);
                    } else {
                        Console.WriteLine("ERRO DE AUTENTICACAO");
                        Console.WriteLine("Aperte uma tecla para retornar");
                        Console.ReadLine();
                    }

                    break;

                // registrar novo usuario
                case 2:
                    ServiceUsuario.Cadastrar(SolicitarDadosCadastrar());
                    break;

                // sair
                case 3:
                    Console.WriteLine("Fim da execucao. Aperte uma tecla para finalizar");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("'TO PERDIDO'");
                    break;
            }
        }

        private static bool Autenticado(Usuario u) {
            return u != null;
        }
    }
}