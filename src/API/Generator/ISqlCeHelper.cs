using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErikEJ.SqlCeScripting
{
    public enum SQLCEVersion
    {
        SQLCE20 = 0,
        SQLCE30 = 1,
        SQLCE35 = 2,
        SQLCE40 = 3
    }

    public interface ISqlCeHelper
    {
        string FormatError(Exception ex);
        string GetFullConnectionString(string connectionString);
        void CompactDatabase(string connectionString, int commandTimeOut = 30);
        void CreateDatabase(string connectionString);
        void VerifyDatabase(string connectionString);
        string ChangeDatabasePassword(string connectionString, string password);
        void RepairDatabaseRecoverAllPossibleRows(string connectionString);
        void RepairDatabaseRecoverAllOrFail(string connectionString);
        void RepairDatabaseDeleteCorruptedRows(string connectionString);
        void ShrinkDatabase(string connectionString, int commandTimeOut = 30);
        string PathFromConnectionString(string connectionString);
        void UpgradeTo40(string connectionString);
        SQLCEVersion DetermineVersion(string fileName);
        /// <summary>
        /// 
        /// </summary>
        /// <returns>null if not installed</returns>
        Version IsV35Installed();
        /// <summary>
        /// 
        /// </summary>
        /// <returns>null if not installed</returns>
        Version IsV40Installed();
        bool IsV35DbProviderInstalled();
        bool IsV40DbProviderInstalled();

        void SaveDataConnection(string repositoryConnectionString, string connectionString, string filePath, int dbType, int commandTimeOut = 30);
        void DeleteDataConnnection(string repositoryConnectionString, string connectionString, int commandTimeOut = 30);
        void UpdateDataConnection(string repositoryConnectionString, string connectionString, string description, int commandTimeOut = 30);
    }
}
