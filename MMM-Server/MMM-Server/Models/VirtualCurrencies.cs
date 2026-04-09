using System.Text.Json.Serialization;

namespace MMM_Server.Models
{
    public enum VirtualCurrencies
    {
        /// <summary>ADA — native token of the Cardano blockchain platform.</summary>
        [JsonPropertyName("ADA")] Ada,

        /// <summary>ALGO — utility token of the Algorand blockchain.</summary>
        [JsonPropertyName("ALGO")] Algo,

        /// <summary>ARKM — token used within the Arkham intelligence platform.</summary>
        [JsonPropertyName("ARKM")] Arkm,

        /// <summary>AUR — token historically associated with the Auroracoin project.</summary>
        [JsonPropertyName("AUR")] Aur,

        /// <summary>AVAX — native asset of the Avalanche smart-contract platform.</summary>
        [JsonPropertyName("AVAX")] Avax,

        /// <summary>BCH — Bitcoin Cash, a fork of Bitcoin focused on larger block sizes.</summary>
        [JsonPropertyName("BCH")] Bch,

        /// <summary>BTC — Bitcoin, the original decentralized digital currency.</summary>
        [JsonPropertyName("BTC")] Btc,

        /// <summary>CKB — Common Knowledge Base token of the Nervos Network.</summary>
        [JsonPropertyName("CKB")] Ckb,

        /// <summary>DASH — digital cash-oriented cryptocurrency offering fast settlement.</summary>
        [JsonPropertyName("DASH")] Dash,

        /// <summary>DESO — token supporting decentralized social-network applications.</summary>
        [JsonPropertyName("DESO")] Deso,

        /// <summary>DOGE — memetic proof-of-work cryptocurrency based on the Dogecoin protocol.</summary>
        [JsonPropertyName("DOGE")] Doge,

        /// <summary>DOT — token of the Polkadot multi-chain interoperability platform.</summary>
        [JsonPropertyName("DOT")] Dot,

        /// <summary>EOS — token used for resources and governance on the EOSIO platform.</summary>
        [JsonPropertyName("EOS")] Eos,

        /// <summary>ETC — Ethereum Classic, maintaining Ethereum's original chain state.</summary>
        [JsonPropertyName("ETC")] Etc,

        /// <summary>ETH — native asset of the Ethereum smart-contract network.</summary>
        [JsonPropertyName("ETH")] Eth,

        /// <summary>FIRO — privacy-oriented cryptocurrency previously known as Zcoin.</summary>
        [JsonPropertyName("FIRO")] Firo,

        /// <summary>GRC — Gridcoin, associated with distributed computing participation.</summary>
        [JsonPropertyName("GRC")] Grc,

        /// <summary>LTC — Litecoin, a peer-to-peer cryptocurrency based on faster block times.</summary>
        [JsonPropertyName("LTC")] Ltc,

        /// <summary>MZC — Mazacoin, historically linked to community-based digital currency projects.</summary>
        [JsonPropertyName("MZC")] Mzc,

        /// <summary>NEO — token powering the Neo smart-economy blockchain.</summary>
        [JsonPropertyName("NEO")] Neo,

        /// <summary>NMC — Namecoin, used for decentralized naming and identity.</summary>
        [JsonPropertyName("NMC")] Nmc,

        /// <summary>NXT — early proof-of-stake cryptocurrency platform.</summary>
        [JsonPropertyName("NXT")] Nxt,

        /// <summary>PPC — Peercoin, one of the earliest proof-of-stake systems.</summary>
        [JsonPropertyName("PPC")] Ppc,

        /// <summary>SAFEMOON — token recognized for its redistribution and fee-based model.</summary>
        [JsonPropertyName("SAFEMOON")] SafeMoon,

        /// <summary>SHIB — Shiba Inu token, an ERC-20 memetic digital asset.</summary>
        [JsonPropertyName("SHIB")] Shib,

        /// <summary>SOL — native token of the Solana high-throughput blockchain.</summary>
        [JsonPropertyName("SOL")] Sol,

        /// <summary>TIT — token name associated with smaller or experimental cryptocurrency projects.</summary>
        [JsonPropertyName("TIT")] Tit,

        /// <summary>TRX — Tron network token supporting smart-contract applications.</summary>
        [JsonPropertyName("TRX")] Trx,

        /// <summary>USDT — Tether, a U.S.-dollar-linked stablecoin.</summary>
        [JsonPropertyName("USDT")] Usdt,

        /// <summary>VTC — Vertcoin, a proof-of-work cryptocurrency emphasizing mining accessibility.</summary>
        [JsonPropertyName("VTC")] Vtc,

        /// <summary>XBT — alternative ticker widely used to denote Bitcoin.</summary>
        [JsonPropertyName("XBT")] Xbt,

        /// <summary>XDG — exchange ticker variant used for Dogecoin.</summary>
        [JsonPropertyName("XDG")] Xdg,

        /// <summary>XLM — Stellar Lumens, token used on the Stellar payments network.</summary>
        [JsonPropertyName("XLM")] Xlm,

        /// <summary>XMR — Monero, a privacy-preserving cryptocurrency.</summary>
        [JsonPropertyName("XMR")] Xmr,

        /// <summary>XNO — Nano, a low-latency digital currency using block-lattice design.</summary>
        [JsonPropertyName("XNO")] Xno,

        /// <summary>XPM — Primecoin, mined via prime-number search algorithms.</summary>
        [JsonPropertyName("XPM")] Xpm,

        /// <summary>XRP — digital asset used on the XRP Ledger for cross-ledger transfers.</summary>
        [JsonPropertyName("XRP")] Xrp,

        /// <summary>XVG — Verge, a privacy-focused cryptocurrency.</summary>
        [JsonPropertyName("XVG")] Xvg,

        /// <summary>ZEC — Zcash, a cryptocurrency offering zero-knowledge privacy features.</summary>
        [JsonPropertyName("ZEC")] Zec
    }
}