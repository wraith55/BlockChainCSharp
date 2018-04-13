using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace BlockChain
{   
    [Serializable]
    class Block
    {   
        // TODO: change type of Data
        private int? index;
        private DateTime time;
        private BlockInfo data;
        private string previousHash;
        private string hash;
        private int nonce = 0;

        internal BlockInfo Data { get => data; }
        public string PreviousHash { get => previousHash; }
        public string Hash { get => hash; }


        public Block(DateTime time, BlockInfo data, string previousHash = "", int? index = null, int? difficulty = null)
        {
            this.index = index;
            this.time = time;
            this.data = data;
            this.previousHash = previousHash;
            this.hash = calculateHash();

            if(!(difficulty == null))
            {
                this.mineBlock(difficulty.Value);
            }            
        }
        
        

        public string getHash()
        {
            return this.hash;
        }

        public string calculateHash()
        {
            SHA256 hasher = SHA256Managed.Create();

            byte[] bytes = ObjectToByteArray(this.index + this.previousHash + this.time + this.data.ToString() + this.nonce);

            byte[] hash = hasher.ComputeHash(bytes);
            var hashString = System.Text.Encoding.Default.GetString(hash);
            return hashString;
        }

        public void mineBlock(int difficulty)
        {
            
            while (this.hash.Substring(0, difficulty) != new string('0', difficulty))
            {
                this.hash = calculateHash();
                this.nonce++;
            }
            Console.WriteLine("block mined: " + this.ToString());

        }

        // Convert an object to a byte array
        public static byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        public override string ToString()
        {
            string ret = "";
            ret += "Block " + this.index + ":\n";
            ret += "\tdata: " + this.data + "\n";
            ret += "\ttime: " + this.time + "\n";
            ret += "\thash: " + this.hash + "\n";
            ret += "\tpreviousHash: " + this.previousHash + "\n";
            return ret;
        }



    }
}
