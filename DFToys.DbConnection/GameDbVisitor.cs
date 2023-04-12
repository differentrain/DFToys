using DFToys.Abstract;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace DFToys.DbConnection
{
    public abstract class GameDbVisitor<TSelf> : IDisposable
        where TSelf : GameDbVisitor<TSelf>
    {

        private static TSelf s_shared = null;

        // 不要升级MySql.Data库，也不要采用Nuget版本
        // 因为>5的版本不支持不安全的连接方式
        // 对于MySql4.1之前的版本而言，不安全的连接方式是必须的

        private MySqlConnection _dbc;


        protected GameDbVisitor(string ip, int port, string user, string password)
        {
            _dbc = null;
            try
            {
                _dbc = new MySqlConnection($"Server={ip};Port={port};User ID={user};Password={password};Allow User Variables=true");
                _dbc.Open();
            }
            catch
            {
                if (_dbc != null)
                    Close();
                throw;
            }
        }

        public static TSelf InitializeShared(string ip, int port, string user, string password)
        {
            s_shared?.Dispose();
            return s_shared = (TSelf)Activator.CreateInstance(typeof(TSelf), ip, port, user, password);
        }

        public static TSelf Shared => s_shared != null && s_shared._dbc != null ? s_shared : throw new InvalidOperationException();


        protected IEnumerable<TRecord> Queue<TRecord, TCreator>(string db, string sql) where TCreator : SingletonRecordCreator<TRecord, TCreator>, new()
        {
            if (db != null)
                _dbc.ChangeDatabase(db);

            using (var command = new MySqlCommand(sql, _dbc))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    var enumerator = new DbEnumerator(reader);
                    while (enumerator.MoveNext())
                    {
                        yield return SingletonRecordCreator<TRecord, TCreator>.Instance.Create(enumerator.Current as IDataRecord);
                    }
                }
            }
        }

        protected IEnumerable<IDataRecord> QueueCore(string db, string sql)
        {
            if (db != null)
                _dbc.ChangeDatabase(db);

            using (var command = new MySqlCommand(sql, _dbc))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    var enumerator = new DbEnumerator(reader);
                    while (enumerator.MoveNext())
                    {
                        yield return enumerator.Current as IDataRecord;
                    }
                }
            }
        }

        protected void NoneQueue(string db, string sql)
        {
            if (db != null)
                _dbc.ChangeDatabase(db);


            using (var command = new MySqlCommand(sql, _dbc))
            {
                command.ExecuteNonQuery();
            }
        }


        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                Close();
        }

        private void Close()
        {
            if (_dbc != null)
            {
                try
                {
                    _dbc.Dispose();
                }
                catch { }
                finally
                {
                    _dbc = null;
                }
            }
        }



    }
}
