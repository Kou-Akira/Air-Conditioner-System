using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace Host {
	class SQLConnector {
		private string configFile = @"sql.xml";
		private XmlNode sqlNode;
		private XmlNode root;
		private string sqlName;
		private string loginName;
		private string loginPassword;
		private string initialCatalog;
		private SqlConnectionStringBuilder builder;

		public SqlConnectionStringBuilder Builder { get => builder; set => builder = value; }

		public SQLConnector() {
			XmlDocument doc = new XmlDocument();
			doc.Load(configFile);
			root = doc.DocumentElement;
			sqlNode = root.SelectSingleNode("sqlconfig");
			sqlName = sqlNode.SelectSingleNode("sqlname").InnerText;
			loginName = sqlNode.SelectSingleNode("loginname").InnerText;
			loginPassword = sqlNode.SelectSingleNode("loginpassword").InnerText;
			initialCatalog = sqlNode.SelectSingleNode("initialcatalog").InnerText;
			Builder = new SqlConnectionStringBuilder();
			Builder.DataSource = sqlName;
			Builder.UserID = loginName;
			Builder.Password = loginPassword;
			Builder.InitialCatalog = initialCatalog;
		}
		public void Print() {
			Console.WriteLine(sqlName + "\n" + loginName + "\n" + loginPassword);
		}

		public DataSet Query(string SQLstr, string tableName) {
			DataSet ds = new DataSet();
			using (SqlConnection con = new SqlConnection(Builder.ConnectionString)) {
				con.Open();
				SqlDataAdapter SQLda = new SqlDataAdapter(SQLstr, con);
				SQLda.Fill(ds, tableName);
			}
			return ds;
		}
	}
}
