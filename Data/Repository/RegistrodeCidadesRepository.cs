using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Services.Interfaces;

namespace Data.Repository
{
    public class RegistrodeCidadesRepository : IRegistrodeCidadeRepository
    {
        
        
        public IEnumerable<RegistrodeCidades> CriandoRegistroTask (List<string> cidadesregistradas, IEnumerable<Usuario> usuario, string filtro = null)
        {
            
            //inicializador
            string[] meses = { "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro" };
            //inicializador valores mensais
            int[] inicializador = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            List<RegistrodeCidades> NRegistros = new List<RegistrodeCidades>();

            foreach (var CidadesRegistradas in cidadesregistradas)
            {
                var registro = new RegistrodeCidades();

                registro.Meses = new List<string>(meses);

                registro.HomensMes = new List<int>(inicializador);

                registro.MulheresMes = new List<int>(inicializador);

                registro.TotalMes = new List<int>(inicializador);

                registro.Cidade = CidadesRegistradas;



                if (filtro == null)
                {
                    foreach (var users in usuario)
                    {


                        if (users.CIDADE == CidadesRegistradas.ToString())
                        {
                            for (int i = 0; i < 12; i++)
                            {
                                if (users.DATA.Month == i + 1)
                                {
                                    if (users.SEXO == "Masculino")
                                    {
                                        registro.HomensMes[i] = registro.HomensMes[i] + 1;
                                        registro.TotalMes[i] = registro.TotalMes[i] + 1;
                                    }
                                    else if (users.SEXO == "Feminino")
                                    {
                                        registro.MulheresMes[i] = registro.MulheresMes[i] + 1;
                                        registro.TotalMes[i] = registro.TotalMes[i] + 1;
                                    }
                                }
                            }
                        }
                    }


                    registro.HomensTotal = 0;
                    registro.MulheresTotal = 0;
                    for (int i = 0; i < 12; i++)
                    {
                        registro.HomensTotal = registro.HomensTotal + registro.HomensMes[i];

                    }

                    for (int i = 0; i < 12; i++)
                    {
                        registro.MulheresTotal = registro.MulheresTotal + registro.MulheresMes[i];

                    }

                    registro.Total = registro.MulheresTotal + registro.HomensTotal;

                    NRegistros.Add(registro);
                }
                else if (filtro != null)
                {

                    foreach (var users in usuario)
                    {


                        if (users.CIDADE == CidadesRegistradas.ToString())
                        {



                            if (users.CIDADE == filtro)
                            {




                                for (int i = 0; i < 12; i++)
                                {
                                    if (users.DATA.Month == i + 1)
                                    {
                                        if (users.SEXO == "Masculino")
                                        {
                                            registro.HomensMes[i] = registro.HomensMes[i] + 1;
                                            registro.TotalMes[i] = registro.TotalMes[i] + 1;
                                        }
                                        else if (users.SEXO == "Feminino")
                                        {
                                            registro.MulheresMes[i] = registro.MulheresMes[i] + 1;
                                            registro.TotalMes[i] = registro.TotalMes[i] + 1;
                                        }
                                    }
                                }






                                registro.HomensTotal = 0;
                                registro.MulheresTotal = 0;
                                for (int i = 0; i < 12; i++)
                                {
                                    registro.HomensTotal = registro.HomensTotal + registro.HomensMes[i];

                                }

                                for (int i = 0; i < 12; i++)
                                {
                                    registro.MulheresTotal = registro.MulheresTotal + registro.MulheresMes[i];

                                }

                                registro.Total = registro.MulheresTotal + registro.HomensTotal;
                                registro.Filtro = filtro;
                                NRegistros.Add(registro);








                            }
                            else if (users.CIDADE != filtro)
                            {
                                registro.Filtro = "Nao Existe";
                                NRegistros.Add(registro);
                            }



                        }


                    }






                }


            }

            IEnumerable<RegistrodeCidades> INRegistros = NRegistros;
            return INRegistros;
        }

        


    }
}