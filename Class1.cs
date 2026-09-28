using System;

class Program
{
    const int QUANTIDADE_NOTAS = 3;
    const double MEDIA_APROVACAO = 7.0;
    const double MEDIA_RECUPERACAO = 5.0;
    const double NOTA_MINIMA = 0.0;
    const double NOTA_MAXIMA = 10.0;

    static string nomeAluno = "";
    static double[] notas = new double[QUANTIDADE_NOTAS];
    static bool alunoCadastrado = false;
    static bool notasLancadas = false;

    static void Main()
    {
        int opcao = 0;

        do
        {
            ExibirMenu();

            Console.Write("Escolha uma opção: ");
            string entrada = Console.ReadLine();

            if (!int.TryParse(entrada, out opcao))
            {
                Console.WriteLine("\nOpção inválida. Digite um número de 1 a 4.");
                Pausar();
                continue;
            }

            Console.Clear();

            switch (opcao)
            {
                case 1:
                    CadastrarAluno();
                    break;

                case 2:
                    LancarNotas();
                    break;

                case 3:
                    CalcularMedia();
                    break;

                case 4:
                    Console.WriteLine("Programa encerrado.");
                    break;

                default:
                    Console.WriteLine("Opção inválida. Escolha uma opção entre 1 e 4.");
                    break;
            }

            if (opcao != 4)
            {
                Pausar();
            }

        } while (opcao != 4);
    }

    static void ExibirMenu()
    {
        Console.Clear();

        Console.WriteLine("==============================");
        Console.WriteLine("     CALCULADORA DE NOTAS");
        Console.WriteLine("==============================");

        if (alunoCadastrado)
        {
            Console.WriteLine($"Aluno: {nomeAluno}");
        }
        else
        {
            Console.WriteLine("Aluno: não cadastrado");
        }

        Console.WriteLine();
        Console.WriteLine("1 - Cadastrar aluno");
        Console.WriteLine("2 - Lançar notas");
        Console.WriteLine("3 - Calcular média");
        Console.WriteLine("4 - Sair");
        Console.WriteLine();
    }

    static void CadastrarAluno()
    {
        Console.WriteLine("=== CADASTRO DO ALUNO ===\n");

        while (true)
        {
            Console.Write("Digite o nome do aluno: ");
            string nomeDigitado = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nomeDigitado))
            {
                Console.WriteLine("Nome inválido. Digite um nome válido.\n");
                continue;
            }

            nomeAluno = nomeDigitado.Trim();
            alunoCadastrado = true;

            // Ao cadastrar outro aluno, as notas anteriores são apagadas.
            notas = new double[QUANTIDADE_NOTAS];
            notasLancadas = false;

            Console.WriteLine($"\nAluno {nomeAluno} cadastrado com sucesso.");
            break;
        }
    }

    static void LancarNotas()
    {
        if (!alunoCadastrado)
        {
            Console.WriteLine("Você precisa cadastrar um aluno antes de lançar as notas.");
            return;
        }

        Console.WriteLine("=== LANÇAMENTO DE NOTAS ===\n");
        Console.WriteLine($"Aluno: {nomeAluno}\n");

        for (int i = 0; i < QUANTIDADE_NOTAS; i++)
        {
            while (true)
            {
                Console.Write($"Digite a nota {i + 1}: ");
                string entradaNota = Console.ReadLine();

                if (!double.TryParse(entradaNota, out double nota))
                {
                    Console.WriteLine("Entrada inválida. Digite um valor numérico.\n");
                    continue;
                }

                if (nota < NOTA_MINIMA || nota > NOTA_MAXIMA)
                {
                    Console.WriteLine(
                        $"Nota inválida. Digite um valor entre {NOTA_MINIMA} e {NOTA_MAXIMA}.\n"
                    );

                    continue;
                }

                notas[i] = nota;
                break;
            }
        }

        notasLancadas = true;

        Console.WriteLine("\nNotas cadastradas com sucesso.");
    }

    static void CalcularMedia()
    {
        if (!alunoCadastrado)
        {
            Console.WriteLine("Você precisa cadastrar um aluno primeiro.");
            return;
        }

        if (!notasLancadas)
        {
            Console.WriteLine("Você precisa lançar as três notas antes de calcular a média.");
            return;
        }

        double somaNotas = 0;

        for (int i = 0; i < notas.Length; i++)
        {
            somaNotas += notas[i];
        }

        double media = somaNotas / QUANTIDADE_NOTAS;

        Console.WriteLine("=== RESULTADO ===\n");
        Console.WriteLine($"Aluno: {nomeAluno}");

        Console.WriteLine(
            $"Notas: {notas[0]:F1} | {notas[1]:F1} | {notas[2]:F1}"
        );

        Console.WriteLine($"Média: {media:F2}");

        ExibirSituacao(media);
    }

    static void ExibirSituacao(double media)
    {
        if (media >= MEDIA_APROVACAO)
        {
            Console.WriteLine("Situação: Aprovado");
        }
        else if (media >= MEDIA_RECUPERACAO)
        {
            Console.WriteLine("Situação: Recuperação");
        }
        else
        {
            Console.WriteLine("Situação: Reprovado");
        }
    }

    static void Pausar()
    {
        Console.WriteLine("\nPressione ENTER para continuar...");
        Console.ReadLine();
    }
}