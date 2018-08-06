using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faceit_Stats
{
    public class Match
    {
        #region Campos

        

        #endregion

        //#region Propriedades

        ///// <summary>
        ///// Receber o escalão de um certa equipa ou modificá-la. GET SET
        ///// </summary>
        //public Escalao Escalao
        //{
        //    get { return _escalao; }
        //    set { _escalao = value; }
        //}

        ///// <summary>
        ///// Número de identificação da Equipa. GET SET
        ///// </summary>
        //internal int internalID { get { return _id; } set { _id = value; } }

        ///// <summary>
        ///// Número de identificação da Equipa. GET
        ///// </summary>
        //public int ID { get { return _id; } }

        ///// <summary>
        ///// Número de identificação da epoca que a equipa está incluida. GET SET
        ///// </summary>
        //public int Season_ID { get { return _season_id; } set { _season_id = value; } }

        ///// <summary>
        ///// Nome da equipa. GET SET
        ///// </summary>
        //public string Nome
        //{
        //    get { return _nome; }
        //    set
        //    {
        //        if (value != "")
        //            _nome = value.Trim();
        //        else
        //            throw new Exception("A equipa precisa de ter um nome");
        //    }
        //}

        //#endregion

        //#region Construtores

        ///// <summary>
        ///// Cria uma equipa com todos os campos
        ///// </summary>
        ///// <param name="id">Número de identificação da equipa</param>
        ///// <param name="season_id">Número de identificação da época em que esta equipa está incluida</param>
        ///// <param name="nome"></param>
        //internal Team(int id, int season_id, string nome, Escalao escalao)
        //{
        //    _id = id;
        //    Season_ID = season_id;
        //    Nome = nome;
        //    Escalao = escalao;
        //}

        ///// <summary>
        ///// Cria uma equipa com os campos necessários
        ///// </summary>
        ///// <param name="season_id">Número de identificação da época em que esta equipa está incluida</param>
        ///// <param name="nome"></param>
        //public Team(int season_id, string nome, Escalao escalao)
        //{
        //    try
        //    {
        //        Season_ID = season_id;
        //        Nome = nome;

        //        _id = new DAL.VMR().CreateTeam(Season_ID, Nome, escalao);
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex is InvalidCastException || ex is System.Data.SqlClient.SqlException ||
        //            ex is System.IO.IOException || ex is InvalidOperationException || ex is ObjectDisposedException)
        //            throw new ServerException(ex);
        //        else
        //            throw ex;
        //    }
        //}

        //private Team() { }

        //#endregion
    }
}
