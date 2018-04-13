using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain
{
    class BlockChain
    {
        private List<Block> chain;
        public BlockChain()
        {
            List<Block> chain = new List<Block>();
            chain.Add(createGenesisBlock());
            this.chain = chain;
        }

        private Block createGenesisBlock()
        {
            BlockInfo info = new BlockInfo(0, "none", "none");
            return new Block(DateTime.Now, info, "", 0);
        }

        public Block getLatestBlock()
        {
            return this.chain.Last();
        }

        public void addBlock(BlockInfo b, int difficulty)
        {
            Block add = new Block(DateTime.Now, b, this.chain.Last().getHash(), this.chain.Count, difficulty);
            this.chain.Add(add);
        }

        public override string ToString()
        {
            string ret = "";
            foreach (Block b in this.chain)
            {
                ret += b.ToString();
            }
            return ret;
        }

        public bool isHashInChain(string hash)
        {
            foreach (Block b in this.chain)
            {
                if (b.Hash == hash) return true; ;
            }
            return false;
        }

        public bool isChainValid()
        {
            for(int i = 1; i < this.chain.Count; i++ )
            {
                Block currBlock = this.chain[i];
                Block prevBlock = this.chain[i - 1];

                if (currBlock.calculateHash() != currBlock.Hash)
                {
                    return false;
                }
                if (currBlock.PreviousHash != prevBlock.Hash)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
