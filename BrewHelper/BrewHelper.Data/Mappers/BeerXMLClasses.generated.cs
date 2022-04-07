
// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class RECIPES
{

    private RECIPESRECIPE[] rECIPEField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("RECIPE")]
    public RECIPESRECIPE[] RECIPE {
        get {
            return this.rECIPEField;
        }
        set {
            this.rECIPEField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class RECIPESRECIPE
{

    private string nAMEField;

    private byte vERSIONField;

    private string tYPEField;

    private string bREWERField;

    private object aSST_BREWERField;

    private decimal bATCH_SIZEField;

    private decimal bOIL_SIZEField;

    private byte bOIL_TIMEField;

    private decimal eFFICIENCYField;

    private RECIPESRECIPEHOP[] hOPSField;

    private RECIPESRECIPEFERMENTABLE[] fERMENTABLESField;

    private RECIPESRECIPEMISC[] mISCSField;

    private RECIPESRECIPEYEAST[] yEASTSField;

    private RECIPESRECIPEWATER[] wATERSField;

    private RECIPESRECIPESTYLE sTYLEField;

    private RECIPESRECIPEEQUIPMENT eQUIPMENTField;

    private RECIPESRECIPEMASH mASHField;

    private string nOTESField;

    private string tASTE_NOTESField;

    private decimal tASTE_RATINGField;

    private decimal ogField;

    private decimal fgField;

    private decimal cARBONATIONField;

    private byte fERMENTATION_STAGESField;

    private byte pRIMARY_AGEField;

    private decimal pRIMARY_TEMPField;

    private byte sECONDARY_AGEField;

    private decimal sECONDARY_TEMPField;

    private byte tERTIARY_AGEField;

    private decimal aGEField;

    private decimal aGE_TEMPField;

    private string cARBONATION_USEDField;

    private string dATEField;

    private string eST_OGField;

    private string eST_FGField;

    private string eST_COLORField;

    private string iBUField;

    private string iBU_METHODField;

    private string eST_ABVField;

    private string aBVField;

    private string aCTUAL_EFFICIENCYField;

    private string cALORIESField;

    private string dISPLAY_BATCH_SIZEField;

    private string dISPLAY_BOIL_SIZEField;

    private string dISPLAY_OGField;

    private string dISPLAY_FGField;

    private string dISPLAY_PRIMARY_TEMPField;

    private string dISPLAY_SECONDARY_TEMPField;

    private string dISPLAY_TERTIARY_TEMPField;

    private string dISPLAY_AGE_TEMPField;

    /// <remarks/>
    public string NAME {
        get {
            return this.nAMEField;
        }
        set {
            this.nAMEField = value;
        }
    }

    /// <remarks/>
    public byte VERSION {
        get {
            return this.vERSIONField;
        }
        set {
            this.vERSIONField = value;
        }
    }

    /// <remarks/>
    public string TYPE {
        get {
            return this.tYPEField;
        }
        set {
            this.tYPEField = value;
        }
    }

    /// <remarks/>
    public string BREWER {
        get {
            return this.bREWERField;
        }
        set {
            this.bREWERField = value;
        }
    }

    /// <remarks/>
    public object ASST_BREWER {
        get {
            return this.aSST_BREWERField;
        }
        set {
            this.aSST_BREWERField = value;
        }
    }

    /// <remarks/>
    public decimal BATCH_SIZE {
        get {
            return this.bATCH_SIZEField;
        }
        set {
            this.bATCH_SIZEField = value;
        }
    }

    /// <remarks/>
    public decimal BOIL_SIZE {
        get {
            return this.bOIL_SIZEField;
        }
        set {
            this.bOIL_SIZEField = value;
        }
    }

    /// <remarks/>
    public byte BOIL_TIME {
        get {
            return this.bOIL_TIMEField;
        }
        set {
            this.bOIL_TIMEField = value;
        }
    }

    /// <remarks/>
    public decimal EFFICIENCY {
        get {
            return this.eFFICIENCYField;
        }
        set {
            this.eFFICIENCYField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("HOP", IsNullable = false)]
    public RECIPESRECIPEHOP[] HOPS {
        get {
            return this.hOPSField;
        }
        set {
            this.hOPSField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("FERMENTABLE", IsNullable = false)]
    public RECIPESRECIPEFERMENTABLE[] FERMENTABLES {
        get {
            return this.fERMENTABLESField;
        }
        set {
            this.fERMENTABLESField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("MISC", IsNullable = false)]
    public RECIPESRECIPEMISC[] MISCS {
        get {
            return this.mISCSField;
        }
        set {
            this.mISCSField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("YEAST", IsNullable = false)]
    public RECIPESRECIPEYEAST[] YEASTS {
        get {
            return this.yEASTSField;
        }
        set {
            this.yEASTSField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("WATER", IsNullable = false)]
    public RECIPESRECIPEWATER[] WATERS {
        get {
            return this.wATERSField;
        }
        set {
            this.wATERSField = value;
        }
    }

    /// <remarks/>
    public RECIPESRECIPESTYLE STYLE {
        get {
            return this.sTYLEField;
        }
        set {
            this.sTYLEField = value;
        }
    }

    /// <remarks/>
    public RECIPESRECIPEEQUIPMENT EQUIPMENT {
        get {
            return this.eQUIPMENTField;
        }
        set {
            this.eQUIPMENTField = value;
        }
    }

    /// <remarks/>
    public RECIPESRECIPEMASH MASH {
        get {
            return this.mASHField;
        }
        set {
            this.mASHField = value;
        }
    }

    /// <remarks/>
    public string NOTES {
        get {
            return this.nOTESField;
        }
        set {
            this.nOTESField = value;
        }
    }

    /// <remarks/>
    public string TASTE_NOTES {
        get {
            return this.tASTE_NOTESField;
        }
        set {
            this.tASTE_NOTESField = value;
        }
    }

    /// <remarks/>
    public decimal TASTE_RATING {
        get {
            return this.tASTE_RATINGField;
        }
        set {
            this.tASTE_RATINGField = value;
        }
    }

    /// <remarks/>
    public decimal OG {
        get {
            return this.ogField;
        }
        set {
            this.ogField = value;
        }
    }

    /// <remarks/>
    public decimal FG {
        get {
            return this.fgField;
        }
        set {
            this.fgField = value;
        }
    }

    /// <remarks/>
    public decimal CARBONATION {
        get {
            return this.cARBONATIONField;
        }
        set {
            this.cARBONATIONField = value;
        }
    }

    /// <remarks/>
    public byte FERMENTATION_STAGES {
        get {
            return this.fERMENTATION_STAGESField;
        }
        set {
            this.fERMENTATION_STAGESField = value;
        }
    }

    /// <remarks/>
    public byte PRIMARY_AGE {
        get {
            return this.pRIMARY_AGEField;
        }
        set {
            this.pRIMARY_AGEField = value;
        }
    }

    /// <remarks/>
    public decimal PRIMARY_TEMP {
        get {
            return this.pRIMARY_TEMPField;
        }
        set {
            this.pRIMARY_TEMPField = value;
        }
    }

    /// <remarks/>
    public byte SECONDARY_AGE {
        get {
            return this.sECONDARY_AGEField;
        }
        set {
            this.sECONDARY_AGEField = value;
        }
    }

    /// <remarks/>
    public decimal SECONDARY_TEMP {
        get {
            return this.sECONDARY_TEMPField;
        }
        set {
            this.sECONDARY_TEMPField = value;
        }
    }

    /// <remarks/>
    public byte TERTIARY_AGE {
        get {
            return this.tERTIARY_AGEField;
        }
        set {
            this.tERTIARY_AGEField = value;
        }
    }

    /// <remarks/>
    public decimal AGE {
        get {
            return this.aGEField;
        }
        set {
            this.aGEField = value;
        }
    }

    /// <remarks/>
    public decimal AGE_TEMP {
        get {
            return this.aGE_TEMPField;
        }
        set {
            this.aGE_TEMPField = value;
        }
    }

    /// <remarks/>
    public string CARBONATION_USED {
        get {
            return this.cARBONATION_USEDField;
        }
        set {
            this.cARBONATION_USEDField = value;
        }
    }

    /// <remarks/>
    public string DATE {
        get {
            return this.dATEField;
        }
        set {
            this.dATEField = value;
        }
    }

    /// <remarks/>
    public string EST_OG {
        get {
            return this.eST_OGField;
        }
        set {
            this.eST_OGField = value;
        }
    }

    /// <remarks/>
    public string EST_FG {
        get {
            return this.eST_FGField;
        }
        set {
            this.eST_FGField = value;
        }
    }

    /// <remarks/>
    public string EST_COLOR {
        get {
            return this.eST_COLORField;
        }
        set {
            this.eST_COLORField = value;
        }
    }

    /// <remarks/>
    public string IBU {
        get {
            return this.iBUField;
        }
        set {
            this.iBUField = value;
        }
    }

    /// <remarks/>
    public string IBU_METHOD {
        get {
            return this.iBU_METHODField;
        }
        set {
            this.iBU_METHODField = value;
        }
    }

    /// <remarks/>
    public string EST_ABV {
        get {
            return this.eST_ABVField;
        }
        set {
            this.eST_ABVField = value;
        }
    }

    /// <remarks/>
    public string ABV {
        get {
            return this.aBVField;
        }
        set {
            this.aBVField = value;
        }
    }

    /// <remarks/>
    public string ACTUAL_EFFICIENCY {
        get {
            return this.aCTUAL_EFFICIENCYField;
        }
        set {
            this.aCTUAL_EFFICIENCYField = value;
        }
    }

    /// <remarks/>
    public string CALORIES {
        get {
            return this.cALORIESField;
        }
        set {
            this.cALORIESField = value;
        }
    }

    /// <remarks/>
    public string DISPLAY_BATCH_SIZE {
        get {
            return this.dISPLAY_BATCH_SIZEField;
        }
        set {
            this.dISPLAY_BATCH_SIZEField = value;
        }
    }

    /// <remarks/>
    public string DISPLAY_BOIL_SIZE {
        get {
            return this.dISPLAY_BOIL_SIZEField;
        }
        set {
            this.dISPLAY_BOIL_SIZEField = value;
        }
    }

    /// <remarks/>
    public string DISPLAY_OG {
        get {
            return this.dISPLAY_OGField;
        }
        set {
            this.dISPLAY_OGField = value;
        }
    }

    /// <remarks/>
    public string DISPLAY_FG {
        get {
            return this.dISPLAY_FGField;
        }
        set {
            this.dISPLAY_FGField = value;
        }
    }

    /// <remarks/>
    public string DISPLAY_PRIMARY_TEMP {
        get {
            return this.dISPLAY_PRIMARY_TEMPField;
        }
        set {
            this.dISPLAY_PRIMARY_TEMPField = value;
        }
    }

    /// <remarks/>
    public string DISPLAY_SECONDARY_TEMP {
        get {
            return this.dISPLAY_SECONDARY_TEMPField;
        }
        set {
            this.dISPLAY_SECONDARY_TEMPField = value;
        }
    }

    /// <remarks/>
    public string DISPLAY_TERTIARY_TEMP {
        get {
            return this.dISPLAY_TERTIARY_TEMPField;
        }
        set {
            this.dISPLAY_TERTIARY_TEMPField = value;
        }
    }

    /// <remarks/>
    public string DISPLAY_AGE_TEMP {
        get {
            return this.dISPLAY_AGE_TEMPField;
        }
        set {
            this.dISPLAY_AGE_TEMPField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class RECIPESRECIPEHOP
{

    private string nAMEField;

    private byte vERSIONField;

    private string oRIGINField;

    private decimal aLPHAField;

    private decimal aMOUNTField;

    private string uSEField;

    private decimal tIMEField;

    private string nOTESField;

    private string tYPEField;

    private string fORMField;

    private decimal bETAField;

    private decimal hSIField;

    private string dISPLAY_AMOUNTField;

    private string iNVENTORYField;

    private string dISPLAY_TIMEField;

    /// <remarks/>
    public string NAME {
        get {
            return this.nAMEField;
        }
        set {
            this.nAMEField = value;
        }
    }

    /// <remarks/>
    public byte VERSION {
        get {
            return this.vERSIONField;
        }
        set {
            this.vERSIONField = value;
        }
    }

    /// <remarks/>
    public string ORIGIN {
        get {
            return this.oRIGINField;
        }
        set {
            this.oRIGINField = value;
        }
    }

    /// <remarks/>
    public decimal ALPHA {
        get {
            return this.aLPHAField;
        }
        set {
            this.aLPHAField = value;
        }
    }

    /// <remarks/>
    public decimal AMOUNT {
        get {
            return this.aMOUNTField;
        }
        set {
            this.aMOUNTField = value;
        }
    }

    /// <remarks/>
    public string USE {
        get {
            return this.uSEField;
        }
        set {
            this.uSEField = value;
        }
    }

    /// <remarks/>
    public decimal TIME {
        get {
            return this.tIMEField;
        }
        set {
            this.tIMEField = value;
        }
    }

    /// <remarks/>
    public string NOTES {
        get {
            return this.nOTESField;
        }
        set {
            this.nOTESField = value;
        }
    }

    /// <remarks/>
    public string TYPE {
        get {
            return this.tYPEField;
        }
        set {
            this.tYPEField = value;
        }
    }

    /// <remarks/>
    public string FORM {
        get {
            return this.fORMField;
        }
        set {
            this.fORMField = value;
        }
    }

    /// <remarks/>
    public decimal BETA {
        get {
            return this.bETAField;
        }
        set {
            this.bETAField = value;
        }
    }

    /// <remarks/>
    public decimal HSI {
        get {
            return this.hSIField;
        }
        set {
            this.hSIField = value;
        }
    }

    /// <remarks/>
    public string DISPLAY_AMOUNT {
        get {
            return this.dISPLAY_AMOUNTField;
        }
        set {
            this.dISPLAY_AMOUNTField = value;
        }
    }

    /// <remarks/>
    public string INVENTORY {
        get {
            return this.iNVENTORYField;
        }
        set {
            this.iNVENTORYField = value;
        }
    }

    /// <remarks/>
    public string DISPLAY_TIME {
        get {
            return this.dISPLAY_TIMEField;
        }
        set {
            this.dISPLAY_TIMEField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class RECIPESRECIPEFERMENTABLE
{

    private string nAMEField;

    private byte vERSIONField;

    private string tYPEField;

    private decimal aMOUNTField;

    private decimal yIELDField;

    private decimal cOLORField;

    private string aDD_AFTER_BOILField;

    private string oRIGINField;

    private object sUPPLIERField;

    private string nOTESField;

    private string cOARSE_FINE_DIFFField;

    private string mOISTUREField;

    private string dIASTATIC_POWERField;

    private string pROTEINField;

    private decimal mAX_IN_BATCHField;

    private string rECOMMEND_MASHField;

    private decimal iBU_GAL_PER_LBField;

    private string dISPLAY_AMOUNTField;

    private string iNVENTORYField;

    private decimal pOTENTIALField;

    private string dISPLAY_COLORField;

    /// <remarks/>
    public string NAME {
        get {
            return this.nAMEField;
        }
        set {
            this.nAMEField = value;
        }
    }

    /// <remarks/>
    public byte VERSION {
        get {
            return this.vERSIONField;
        }
        set {
            this.vERSIONField = value;
        }
    }

    /// <remarks/>
    public string TYPE {
        get {
            return this.tYPEField;
        }
        set {
            this.tYPEField = value;
        }
    }

    /// <remarks/>
    public decimal AMOUNT {
        get {
            return this.aMOUNTField;
        }
        set {
            this.aMOUNTField = value;
        }
    }

    /// <remarks/>
    public decimal YIELD {
        get {
            return this.yIELDField;
        }
        set {
            this.yIELDField = value;
        }
    }

    /// <remarks/>
    public decimal COLOR {
        get {
            return this.cOLORField;
        }
        set {
            this.cOLORField = value;
        }
    }

    /// <remarks/>
    public string ADD_AFTER_BOIL {
        get {
            return this.aDD_AFTER_BOILField;
        }
        set {
            this.aDD_AFTER_BOILField = value;
        }
    }

    /// <remarks/>
    public string ORIGIN {
        get {
            return this.oRIGINField;
        }
        set {
            this.oRIGINField = value;
        }
    }

    /// <remarks/>
    public object SUPPLIER {
        get {
            return this.sUPPLIERField;
        }
        set {
            this.sUPPLIERField = value;
        }
    }

    /// <remarks/>
    public string NOTES {
        get {
            return this.nOTESField;
        }
        set {
            this.nOTESField = value;
        }
    }

    /// <remarks/>
    public string COARSE_FINE_DIFF {
        get {
            return this.cOARSE_FINE_DIFFField;
        }
        set {
            this.cOARSE_FINE_DIFFField = value;
        }
    }

    /// <remarks/>
    public string MOISTURE {
        get {
            return this.mOISTUREField;
        }
        set {
            this.mOISTUREField = value;
        }
    }

    /// <remarks/>
    public string DIASTATIC_POWER {
        get {
            return this.dIASTATIC_POWERField;
        }
        set {
            this.dIASTATIC_POWERField = value;
        }
    }

    /// <remarks/>
    public string PROTEIN {
        get {
            return this.pROTEINField;
        }
        set {
            this.pROTEINField = value;
        }
    }

    /// <remarks/>
    public decimal MAX_IN_BATCH {
        get {
            return this.mAX_IN_BATCHField;
        }
        set {
            this.mAX_IN_BATCHField = value;
        }
    }

    /// <remarks/>
    public string RECOMMEND_MASH {
        get {
            return this.rECOMMEND_MASHField;
        }
        set {
            this.rECOMMEND_MASHField = value;
        }
    }

    /// <remarks/>
    public decimal IBU_GAL_PER_LB {
        get {
            return this.iBU_GAL_PER_LBField;
        }
        set {
            this.iBU_GAL_PER_LBField = value;
        }
    }

    /// <remarks/>
    public string DISPLAY_AMOUNT {
        get {
            return this.dISPLAY_AMOUNTField;
        }
        set {
            this.dISPLAY_AMOUNTField = value;
        }
    }

    /// <remarks/>
    public string INVENTORY {
        get {
            return this.iNVENTORYField;
        }
        set {
            this.iNVENTORYField = value;
        }
    }

    /// <remarks/>
    public decimal POTENTIAL {
        get {
            return this.pOTENTIALField;
        }
        set {
            this.pOTENTIALField = value;
        }
    }

    /// <remarks/>
    public string DISPLAY_COLOR {
        get {
            return this.dISPLAY_COLORField;
        }
        set {
            this.dISPLAY_COLORField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class RECIPESRECIPEMISC
{

    private string nAMEField;

    private byte vERSIONField;

    private string tYPEField;

    private string uSEField;

    private decimal aMOUNTField;

    private decimal tIMEField;

    private string aMOUNT_IS_WEIGHTField;

    private string uSE_FORField;

    private string nOTESField;

    private string dISPLAY_AMOUNTField;

    private string iNVENTORYField;

    private string dISPLAY_TIMEField;

    private string bATCH_SIZEField;

    /// <remarks/>
    public string NAME {
        get {
            return this.nAMEField;
        }
        set {
            this.nAMEField = value;
        }
    }

    /// <remarks/>
    public byte VERSION {
        get {
            return this.vERSIONField;
        }
        set {
            this.vERSIONField = value;
        }
    }

    /// <remarks/>
    public string TYPE {
        get {
            return this.tYPEField;
        }
        set {
            this.tYPEField = value;
        }
    }

    /// <remarks/>
    public string USE {
        get {
            return this.uSEField;
        }
        set {
            this.uSEField = value;
        }
    }

    /// <remarks/>
    public decimal AMOUNT {
        get {
            return this.aMOUNTField;
        }
        set {
            this.aMOUNTField = value;
        }
    }

    /// <remarks/>
    public decimal TIME {
        get {
            return this.tIMEField;
        }
        set {
            this.tIMEField = value;
        }
    }

    /// <remarks/>
    public string AMOUNT_IS_WEIGHT {
        get {
            return this.aMOUNT_IS_WEIGHTField;
        }
        set {
            this.aMOUNT_IS_WEIGHTField = value;
        }
    }

    /// <remarks/>
    public string USE_FOR {
        get {
            return this.uSE_FORField;
        }
        set {
            this.uSE_FORField = value;
        }
    }

    /// <remarks/>
    public string NOTES {
        get {
            return this.nOTESField;
        }
        set {
            this.nOTESField = value;
        }
    }

    /// <remarks/>
    public string DISPLAY_AMOUNT {
        get {
            return this.dISPLAY_AMOUNTField;
        }
        set {
            this.dISPLAY_AMOUNTField = value;
        }
    }

    /// <remarks/>
    public string INVENTORY {
        get {
            return this.iNVENTORYField;
        }
        set {
            this.iNVENTORYField = value;
        }
    }

    /// <remarks/>
    public string DISPLAY_TIME {
        get {
            return this.dISPLAY_TIMEField;
        }
        set {
            this.dISPLAY_TIMEField = value;
        }
    }

    /// <remarks/>
    public string BATCH_SIZE {
        get {
            return this.bATCH_SIZEField;
        }
        set {
            this.bATCH_SIZEField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class RECIPESRECIPEYEAST
{

    private string nAMEField;

    private byte vERSIONField;

    private string tYPEField;

    private string fORMField;

    private decimal aMOUNTField;

    private string aMOUNT_IS_WEIGHTField;

    private string lABORATORYField;

    private string pRODUCT_IDField;

    private decimal mIN_TEMPERATUREField;

    private decimal mAX_TEMPERATUREField;

    private string fLOCCULATIONField;

    private decimal aTTENUATIONField;

    private string nOTESField;

    private string bEST_FORField;

    private byte mAX_REUSEField;

    private byte tIMES_CULTUREDField;

    private string aDD_TO_SECONDARYField;

    private string dISPLAY_AMOUNTField;

    private string dISP_MIN_TEMPField;

    private string dISP_MAX_TEMPField;

    private string iNVENTORYField;

    private string cULTURE_DATEField;

    /// <remarks/>
    public string NAME {
        get {
            return this.nAMEField;
        }
        set {
            this.nAMEField = value;
        }
    }

    /// <remarks/>
    public byte VERSION {
        get {
            return this.vERSIONField;
        }
        set {
            this.vERSIONField = value;
        }
    }

    /// <remarks/>
    public string TYPE {
        get {
            return this.tYPEField;
        }
        set {
            this.tYPEField = value;
        }
    }

    /// <remarks/>
    public string FORM {
        get {
            return this.fORMField;
        }
        set {
            this.fORMField = value;
        }
    }

    /// <remarks/>
    public decimal AMOUNT {
        get {
            return this.aMOUNTField;
        }
        set {
            this.aMOUNTField = value;
        }
    }

    /// <remarks/>
    public string AMOUNT_IS_WEIGHT {
        get {
            return this.aMOUNT_IS_WEIGHTField;
        }
        set {
            this.aMOUNT_IS_WEIGHTField = value;
        }
    }

    /// <remarks/>
    public string LABORATORY {
        get {
            return this.lABORATORYField;
        }
        set {
            this.lABORATORYField = value;
        }
    }

    /// <remarks/>
    public string PRODUCT_ID {
        get {
            return this.pRODUCT_IDField;
        }
        set {
            this.pRODUCT_IDField = value;
        }
    }

    /// <remarks/>
    public decimal MIN_TEMPERATURE {
        get {
            return this.mIN_TEMPERATUREField;
        }
        set {
            this.mIN_TEMPERATUREField = value;
        }
    }

    /// <remarks/>
    public decimal MAX_TEMPERATURE {
        get {
            return this.mAX_TEMPERATUREField;
        }
        set {
            this.mAX_TEMPERATUREField = value;
        }
    }

    /// <remarks/>
    public string FLOCCULATION {
        get {
            return this.fLOCCULATIONField;
        }
        set {
            this.fLOCCULATIONField = value;
        }
    }

    /// <remarks/>
    public decimal ATTENUATION {
        get {
            return this.aTTENUATIONField;
        }
        set {
            this.aTTENUATIONField = value;
        }
    }

    /// <remarks/>
    public string NOTES {
        get {
            return this.nOTESField;
        }
        set {
            this.nOTESField = value;
        }
    }

    /// <remarks/>
    public string BEST_FOR {
        get {
            return this.bEST_FORField;
        }
        set {
            this.bEST_FORField = value;
        }
    }

    /// <remarks/>
    public byte MAX_REUSE {
        get {
            return this.mAX_REUSEField;
        }
        set {
            this.mAX_REUSEField = value;
        }
    }

    /// <remarks/>
    public byte TIMES_CULTURED {
        get {
            return this.tIMES_CULTUREDField;
        }
        set {
            this.tIMES_CULTUREDField = value;
        }
    }

    /// <remarks/>
    public string ADD_TO_SECONDARY {
        get {
            return this.aDD_TO_SECONDARYField;
        }
        set {
            this.aDD_TO_SECONDARYField = value;
        }
    }

    /// <remarks/>
    public string DISPLAY_AMOUNT {
        get {
            return this.dISPLAY_AMOUNTField;
        }
        set {
            this.dISPLAY_AMOUNTField = value;
        }
    }

    /// <remarks/>
    public string DISP_MIN_TEMP {
        get {
            return this.dISP_MIN_TEMPField;
        }
        set {
            this.dISP_MIN_TEMPField = value;
        }
    }

    /// <remarks/>
    public string DISP_MAX_TEMP {
        get {
            return this.dISP_MAX_TEMPField;
        }
        set {
            this.dISP_MAX_TEMPField = value;
        }
    }

    /// <remarks/>
    public string INVENTORY {
        get {
            return this.iNVENTORYField;
        }
        set {
            this.iNVENTORYField = value;
        }
    }

    /// <remarks/>
    public string CULTURE_DATE {
        get {
            return this.cULTURE_DATEField;
        }
        set {
            this.cULTURE_DATEField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class RECIPESRECIPEWATER
{

    private string nAMEField;

    private byte vERSIONField;

    private decimal aMOUNTField;

    private decimal cALCIUMField;

    private decimal bICARBONATEField;

    private decimal sULFATEField;

    private decimal cHLORIDEField;

    private decimal sODIUMField;

    private decimal mAGNESIUMField;

    private decimal phField;

    private string nOTESField;

    private string dISPLAY_AMOUNTField;

    /// <remarks/>
    public string NAME {
        get {
            return this.nAMEField;
        }
        set {
            this.nAMEField = value;
        }
    }

    /// <remarks/>
    public byte VERSION {
        get {
            return this.vERSIONField;
        }
        set {
            this.vERSIONField = value;
        }
    }

    /// <remarks/>
    public decimal AMOUNT {
        get {
            return this.aMOUNTField;
        }
        set {
            this.aMOUNTField = value;
        }
    }

    /// <remarks/>
    public decimal CALCIUM {
        get {
            return this.cALCIUMField;
        }
        set {
            this.cALCIUMField = value;
        }
    }

    /// <remarks/>
    public decimal BICARBONATE {
        get {
            return this.bICARBONATEField;
        }
        set {
            this.bICARBONATEField = value;
        }
    }

    /// <remarks/>
    public decimal SULFATE {
        get {
            return this.sULFATEField;
        }
        set {
            this.sULFATEField = value;
        }
    }

    /// <remarks/>
    public decimal CHLORIDE {
        get {
            return this.cHLORIDEField;
        }
        set {
            this.cHLORIDEField = value;
        }
    }

    /// <remarks/>
    public decimal SODIUM {
        get {
            return this.sODIUMField;
        }
        set {
            this.sODIUMField = value;
        }
    }

    /// <remarks/>
    public decimal MAGNESIUM {
        get {
            return this.mAGNESIUMField;
        }
        set {
            this.mAGNESIUMField = value;
        }
    }

    /// <remarks/>
    public decimal PH {
        get {
            return this.phField;
        }
        set {
            this.phField = value;
        }
    }

    /// <remarks/>
    public string NOTES {
        get {
            return this.nOTESField;
        }
        set {
            this.nOTESField = value;
        }
    }

    /// <remarks/>
    public string DISPLAY_AMOUNT {
        get {
            return this.dISPLAY_AMOUNTField;
        }
        set {
            this.dISPLAY_AMOUNTField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class RECIPESRECIPESTYLE
{

    private string nAMEField;

    private byte vERSIONField;

    private string cATEGORYField;

    private string cATEGORY_NUMBERField;

    private string sTYLE_LETTERField;

    private string sTYLE_GUIDEField;

    private string tYPEField;

    private decimal oG_MINField;

    private decimal oG_MAXField;

    private decimal fG_MINField;

    private decimal fG_MAXField;

    private decimal iBU_MINField;

    private decimal iBU_MAXField;

    private decimal cOLOR_MINField;

    private decimal cOLOR_MAXField;

    private decimal cARB_MINField;

    private string cARB_MAXField;

    private decimal aBV_MAXField;

    private decimal aBV_MINField;

    private string nOTESField;

    private string pROFILEField;

    private string iNGREDIENTSField;

    private string eXAMPLESField;

    private string dISPLAY_OG_MINField;

    private string dISPLAY_OG_MAXField;

    private string dISPLAY_FG_MINField;

    private string dISPLAY_FG_MAXField;

    private string dISPLAY_COLOR_MINField;

    private string dISPLAY_COLOR_MAXField;

    private string oG_RANGEField;

    private string fG_RANGEField;

    private string iBU_RANGEField;

    private string cARB_RANGEField;

    private string cOLOR_RANGEField;

    private string aBV_RANGEField;

    /// <remarks/>
    public string NAME {
        get {
            return this.nAMEField;
        }
        set {
            this.nAMEField = value;
        }
    }

    /// <remarks/>
    public byte VERSION {
        get {
            return this.vERSIONField;
        }
        set {
            this.vERSIONField = value;
        }
    }

    /// <remarks/>
    public string CATEGORY {
        get {
            return this.cATEGORYField;
        }
        set {
            this.cATEGORYField = value;
        }
    }

    /// <remarks/>
    public string CATEGORY_NUMBER {
        get {
            return this.cATEGORY_NUMBERField;
        }
        set {
            this.cATEGORY_NUMBERField = value;
        }
    }

    /// <remarks/>
    public string STYLE_LETTER {
        get {
            return this.sTYLE_LETTERField;
        }
        set {
            this.sTYLE_LETTERField = value;
        }
    }

    /// <remarks/>
    public string STYLE_GUIDE {
        get {
            return this.sTYLE_GUIDEField;
        }
        set {
            this.sTYLE_GUIDEField = value;
        }
    }

    /// <remarks/>
    public string TYPE {
        get {
            return this.tYPEField;
        }
        set {
            this.tYPEField = value;
        }
    }

    /// <remarks/>
    public decimal OG_MIN {
        get {
            return this.oG_MINField;
        }
        set {
            this.oG_MINField = value;
        }
    }

    /// <remarks/>
    public decimal OG_MAX {
        get {
            return this.oG_MAXField;
        }
        set {
            this.oG_MAXField = value;
        }
    }

    /// <remarks/>
    public decimal FG_MIN {
        get {
            return this.fG_MINField;
        }
        set {
            this.fG_MINField = value;
        }
    }

    /// <remarks/>
    public decimal FG_MAX {
        get {
            return this.fG_MAXField;
        }
        set {
            this.fG_MAXField = value;
        }
    }

    /// <remarks/>
    public decimal IBU_MIN {
        get {
            return this.iBU_MINField;
        }
        set {
            this.iBU_MINField = value;
        }
    }

    /// <remarks/>
    public decimal IBU_MAX {
        get {
            return this.iBU_MAXField;
        }
        set {
            this.iBU_MAXField = value;
        }
    }

    /// <remarks/>
    public decimal COLOR_MIN {
        get {
            return this.cOLOR_MINField;
        }
        set {
            this.cOLOR_MINField = value;
        }
    }

    /// <remarks/>
    public decimal COLOR_MAX {
        get {
            return this.cOLOR_MAXField;
        }
        set {
            this.cOLOR_MAXField = value;
        }
    }

    /// <remarks/>
    public decimal CARB_MIN {
        get {
            return this.cARB_MINField;
        }
        set {
            this.cARB_MINField = value;
        }
    }

    /// <remarks/>
    public string CARB_MAX {
        get {
            return this.cARB_MAXField;
        }
        set {
            this.cARB_MAXField = value;
        }
    }

    /// <remarks/>
    public decimal ABV_MAX {
        get {
            return this.aBV_MAXField;
        }
        set {
            this.aBV_MAXField = value;
        }
    }

    /// <remarks/>
    public decimal ABV_MIN {
        get {
            return this.aBV_MINField;
        }
        set {
            this.aBV_MINField = value;
        }
    }

    /// <remarks/>
    public string NOTES {
        get {
            return this.nOTESField;
        }
        set {
            this.nOTESField = value;
        }
    }

    /// <remarks/>
    public string PROFILE {
        get {
            return this.pROFILEField;
        }
        set {
            this.pROFILEField = value;
        }
    }

    /// <remarks/>
    public string INGREDIENTS {
        get {
            return this.iNGREDIENTSField;
        }
        set {
            this.iNGREDIENTSField = value;
        }
    }

    /// <remarks/>
    public string EXAMPLES {
        get {
            return this.eXAMPLESField;
        }
        set {
            this.eXAMPLESField = value;
        }
    }

    /// <remarks/>
    public string DISPLAY_OG_MIN {
        get {
            return this.dISPLAY_OG_MINField;
        }
        set {
            this.dISPLAY_OG_MINField = value;
        }
    }

    /// <remarks/>
    public string DISPLAY_OG_MAX {
        get {
            return this.dISPLAY_OG_MAXField;
        }
        set {
            this.dISPLAY_OG_MAXField = value;
        }
    }

    /// <remarks/>
    public string DISPLAY_FG_MIN {
        get {
            return this.dISPLAY_FG_MINField;
        }
        set {
            this.dISPLAY_FG_MINField = value;
        }
    }

    /// <remarks/>
    public string DISPLAY_FG_MAX {
        get {
            return this.dISPLAY_FG_MAXField;
        }
        set {
            this.dISPLAY_FG_MAXField = value;
        }
    }

    /// <remarks/>
    public string DISPLAY_COLOR_MIN {
        get {
            return this.dISPLAY_COLOR_MINField;
        }
        set {
            this.dISPLAY_COLOR_MINField = value;
        }
    }

    /// <remarks/>
    public string DISPLAY_COLOR_MAX {
        get {
            return this.dISPLAY_COLOR_MAXField;
        }
        set {
            this.dISPLAY_COLOR_MAXField = value;
        }
    }

    /// <remarks/>
    public string OG_RANGE {
        get {
            return this.oG_RANGEField;
        }
        set {
            this.oG_RANGEField = value;
        }
    }

    /// <remarks/>
    public string FG_RANGE {
        get {
            return this.fG_RANGEField;
        }
        set {
            this.fG_RANGEField = value;
        }
    }

    /// <remarks/>
    public string IBU_RANGE {
        get {
            return this.iBU_RANGEField;
        }
        set {
            this.iBU_RANGEField = value;
        }
    }

    /// <remarks/>
    public string CARB_RANGE {
        get {
            return this.cARB_RANGEField;
        }
        set {
            this.cARB_RANGEField = value;
        }
    }

    /// <remarks/>
    public string COLOR_RANGE {
        get {
            return this.cOLOR_RANGEField;
        }
        set {
            this.cOLOR_RANGEField = value;
        }
    }

    /// <remarks/>
    public string ABV_RANGE {
        get {
            return this.aBV_RANGEField;
        }
        set {
            this.aBV_RANGEField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class RECIPESRECIPEEQUIPMENT
{

    private string nAMEField;

    private byte vERSIONField;

    private decimal bOIL_SIZEField;

    private decimal bATCH_SIZEField;

    private decimal tUN_VOLUMEField;

    private decimal tUN_WEIGHTField;

    private decimal tUN_SPECIFIC_HEATField;

    private decimal tOP_UP_WATERField;

    private decimal tRUB_CHILLER_LOSSField;

    private decimal eVAP_RATEField;

    private decimal bOIL_TIMEField;

    private string cALC_BOIL_VOLUMEField;

    private decimal lAUTER_DEADSPACEField;

    private decimal tOP_UP_KETTLEField;

    private decimal hOP_UTILIZATIONField;

    private string nOTESField;

    private string dISPLAY_BOIL_SIZEField;

    private string dISPLAY_BATCH_SIZEField;

    private string dISPLAY_TUN_VOLUMEField;

    private string dISPLAY_TUN_WEIGHTField;

    private string dISPLAY_TOP_UP_WATERField;

    private string dISPLAY_TRUB_CHILLER_LOSSField;

    private string dISPLAY_LAUTER_DEADSPACEField;

    private string dISPLAY_TOP_UP_KETTLEField;

    /// <remarks/>
    public string NAME {
        get {
            return this.nAMEField;
        }
        set {
            this.nAMEField = value;
        }
    }

    /// <remarks/>
    public byte VERSION {
        get {
            return this.vERSIONField;
        }
        set {
            this.vERSIONField = value;
        }
    }

    /// <remarks/>
    public decimal BOIL_SIZE {
        get {
            return this.bOIL_SIZEField;
        }
        set {
            this.bOIL_SIZEField = value;
        }
    }

    /// <remarks/>
    public decimal BATCH_SIZE {
        get {
            return this.bATCH_SIZEField;
        }
        set {
            this.bATCH_SIZEField = value;
        }
    }

    /// <remarks/>
    public decimal TUN_VOLUME {
        get {
            return this.tUN_VOLUMEField;
        }
        set {
            this.tUN_VOLUMEField = value;
        }
    }

    /// <remarks/>
    public decimal TUN_WEIGHT {
        get {
            return this.tUN_WEIGHTField;
        }
        set {
            this.tUN_WEIGHTField = value;
        }
    }

    /// <remarks/>
    public decimal TUN_SPECIFIC_HEAT {
        get {
            return this.tUN_SPECIFIC_HEATField;
        }
        set {
            this.tUN_SPECIFIC_HEATField = value;
        }
    }

    /// <remarks/>
    public decimal TOP_UP_WATER {
        get {
            return this.tOP_UP_WATERField;
        }
        set {
            this.tOP_UP_WATERField = value;
        }
    }

    /// <remarks/>
    public decimal TRUB_CHILLER_LOSS {
        get {
            return this.tRUB_CHILLER_LOSSField;
        }
        set {
            this.tRUB_CHILLER_LOSSField = value;
        }
    }

    /// <remarks/>
    public decimal EVAP_RATE {
        get {
            return this.eVAP_RATEField;
        }
        set {
            this.eVAP_RATEField = value;
        }
    }

    /// <remarks/>
    public decimal BOIL_TIME {
        get {
            return this.bOIL_TIMEField;
        }
        set {
            this.bOIL_TIMEField = value;
        }
    }

    /// <remarks/>
    public string CALC_BOIL_VOLUME {
        get {
            return this.cALC_BOIL_VOLUMEField;
        }
        set {
            this.cALC_BOIL_VOLUMEField = value;
        }
    }

    /// <remarks/>
    public decimal LAUTER_DEADSPACE {
        get {
            return this.lAUTER_DEADSPACEField;
        }
        set {
            this.lAUTER_DEADSPACEField = value;
        }
    }

    /// <remarks/>
    public decimal TOP_UP_KETTLE {
        get {
            return this.tOP_UP_KETTLEField;
        }
        set {
            this.tOP_UP_KETTLEField = value;
        }
    }

    /// <remarks/>
    public decimal HOP_UTILIZATION {
        get {
            return this.hOP_UTILIZATIONField;
        }
        set {
            this.hOP_UTILIZATIONField = value;
        }
    }

    /// <remarks/>
    public string NOTES {
        get {
            return this.nOTESField;
        }
        set {
            this.nOTESField = value;
        }
    }

    /// <remarks/>
    public string DISPLAY_BOIL_SIZE {
        get {
            return this.dISPLAY_BOIL_SIZEField;
        }
        set {
            this.dISPLAY_BOIL_SIZEField = value;
        }
    }

    /// <remarks/>
    public string DISPLAY_BATCH_SIZE {
        get {
            return this.dISPLAY_BATCH_SIZEField;
        }
        set {
            this.dISPLAY_BATCH_SIZEField = value;
        }
    }

    /// <remarks/>
    public string DISPLAY_TUN_VOLUME {
        get {
            return this.dISPLAY_TUN_VOLUMEField;
        }
        set {
            this.dISPLAY_TUN_VOLUMEField = value;
        }
    }

    /// <remarks/>
    public string DISPLAY_TUN_WEIGHT {
        get {
            return this.dISPLAY_TUN_WEIGHTField;
        }
        set {
            this.dISPLAY_TUN_WEIGHTField = value;
        }
    }

    /// <remarks/>
    public string DISPLAY_TOP_UP_WATER {
        get {
            return this.dISPLAY_TOP_UP_WATERField;
        }
        set {
            this.dISPLAY_TOP_UP_WATERField = value;
        }
    }

    /// <remarks/>
    public string DISPLAY_TRUB_CHILLER_LOSS {
        get {
            return this.dISPLAY_TRUB_CHILLER_LOSSField;
        }
        set {
            this.dISPLAY_TRUB_CHILLER_LOSSField = value;
        }
    }

    /// <remarks/>
    public string DISPLAY_LAUTER_DEADSPACE {
        get {
            return this.dISPLAY_LAUTER_DEADSPACEField;
        }
        set {
            this.dISPLAY_LAUTER_DEADSPACEField = value;
        }
    }

    /// <remarks/>
    public string DISPLAY_TOP_UP_KETTLE {
        get {
            return this.dISPLAY_TOP_UP_KETTLEField;
        }
        set {
            this.dISPLAY_TOP_UP_KETTLEField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class RECIPESRECIPEMASH
{

    private string nAMEField;

    private byte vERSIONField;

    private decimal gRAIN_TEMPField;

    private decimal tUN_TEMPField;

    private decimal sPARGE_TEMPField;

    private decimal phField;

    private decimal tUN_WEIGHTField;

    private decimal tUN_SPECIFIC_HEATField;

    private string eQUIP_ADJUSTField;

    private string nOTESField;

    private string dISPLAY_GRAIN_TEMPField;

    private decimal dISPLAY_TUN_TEMPField;

    private string dISPLAY_SPARGE_TEMPField;

    private string dISPLAY_TUN_WEIGHTField;

    private RECIPESRECIPEMASHMASH_STEP[] mASH_STEPSField;

    /// <remarks/>
    public string NAME {
        get {
            return this.nAMEField;
        }
        set {
            this.nAMEField = value;
        }
    }

    /// <remarks/>
    public byte VERSION {
        get {
            return this.vERSIONField;
        }
        set {
            this.vERSIONField = value;
        }
    }

    /// <remarks/>
    public decimal GRAIN_TEMP {
        get {
            return this.gRAIN_TEMPField;
        }
        set {
            this.gRAIN_TEMPField = value;
        }
    }

    /// <remarks/>
    public decimal TUN_TEMP {
        get {
            return this.tUN_TEMPField;
        }
        set {
            this.tUN_TEMPField = value;
        }
    }

    /// <remarks/>
    public decimal SPARGE_TEMP {
        get {
            return this.sPARGE_TEMPField;
        }
        set {
            this.sPARGE_TEMPField = value;
        }
    }

    /// <remarks/>
    public decimal PH {
        get {
            return this.phField;
        }
        set {
            this.phField = value;
        }
    }

    /// <remarks/>
    public decimal TUN_WEIGHT {
        get {
            return this.tUN_WEIGHTField;
        }
        set {
            this.tUN_WEIGHTField = value;
        }
    }

    /// <remarks/>
    public decimal TUN_SPECIFIC_HEAT {
        get {
            return this.tUN_SPECIFIC_HEATField;
        }
        set {
            this.tUN_SPECIFIC_HEATField = value;
        }
    }

    /// <remarks/>
    public string EQUIP_ADJUST {
        get {
            return this.eQUIP_ADJUSTField;
        }
        set {
            this.eQUIP_ADJUSTField = value;
        }
    }

    /// <remarks/>
    public string NOTES {
        get {
            return this.nOTESField;
        }
        set {
            this.nOTESField = value;
        }
    }

    /// <remarks/>
    public string DISPLAY_GRAIN_TEMP {
        get {
            return this.dISPLAY_GRAIN_TEMPField;
        }
        set {
            this.dISPLAY_GRAIN_TEMPField = value;
        }
    }

    /// <remarks/>
    public decimal DISPLAY_TUN_TEMP {
        get {
            return this.dISPLAY_TUN_TEMPField;
        }
        set {
            this.dISPLAY_TUN_TEMPField = value;
        }
    }

    /// <remarks/>
    public string DISPLAY_SPARGE_TEMP {
        get {
            return this.dISPLAY_SPARGE_TEMPField;
        }
        set {
            this.dISPLAY_SPARGE_TEMPField = value;
        }
    }

    /// <remarks/>
    public string DISPLAY_TUN_WEIGHT {
        get {
            return this.dISPLAY_TUN_WEIGHTField;
        }
        set {
            this.dISPLAY_TUN_WEIGHTField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("MASH_STEP", IsNullable = false)]
    public RECIPESRECIPEMASHMASH_STEP[] MASH_STEPS {
        get {
            return this.mASH_STEPSField;
        }
        set {
            this.mASH_STEPSField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class RECIPESRECIPEMASHMASH_STEP
{

    private string nAMEField;

    private byte vERSIONField;

    private string tYPEField;

    private decimal? iNFUSE_AMOUNTField;

    private int sTEP_TIMEField;

    private decimal sTEP_TEMPField;

    private int rAMP_TIMEField;

    private decimal eND_TEMPField;

    private string dESCRIPTIONField;

    private decimal wATER_GRAIN_RATIOField;

    private string dECOCTION_AMTField;

    private string iNFUSE_TEMPField;

    private string dISPLAY_STEP_TEMPField;

    private string dISPLAY_INFUSE_AMTField;

    /// <remarks/>
    public string NAME {
        get {
            return this.nAMEField;
        }
        set {
            this.nAMEField = value;
        }
    }

    /// <remarks/>
    public byte VERSION {
        get {
            return this.vERSIONField;
        }
        set {
            this.vERSIONField = value;
        }
    }

    /// <remarks/>
    public string TYPE {
        get {
            return this.tYPEField;
        }
        set {
            this.tYPEField = value;
        }
    }

    /// <remarks/>
    public decimal? INFUSE_AMOUNT {
        get {
            return this.iNFUSE_AMOUNTField;
        }
        set {
            this.iNFUSE_AMOUNTField = value;
        }
    }

    /// <remarks/>
    public int STEP_TIME {
        get {
            return this.sTEP_TIMEField;
        }
        set {
            this.sTEP_TIMEField = value;
        }
    }

    /// <remarks/>
    public decimal STEP_TEMP {
        get {
            return this.sTEP_TEMPField;
        }
        set {
            this.sTEP_TEMPField = value;
        }
    }

    /// <remarks/>
    public int RAMP_TIME {
        get {
            return this.rAMP_TIMEField;
        }
        set {
            this.rAMP_TIMEField = value;
        }
    }

    /// <remarks/>
    public decimal END_TEMP {
        get {
            return this.eND_TEMPField;
        }
        set {
            this.eND_TEMPField = value;
        }
    }

    /// <remarks/>
    public string DESCRIPTION {
        get {
            return this.dESCRIPTIONField;
        }
        set {
            this.dESCRIPTIONField = value;
        }
    }

    /// <remarks/>
    public decimal WATER_GRAIN_RATIO {
        get {
            return this.wATER_GRAIN_RATIOField;
        }
        set {
            this.wATER_GRAIN_RATIOField = value;
        }
    }

    /// <remarks/>
    public string DECOCTION_AMT {
        get {
            return this.dECOCTION_AMTField;
        }
        set {
            this.dECOCTION_AMTField = value;
        }
    }

    /// <remarks/>
    public string INFUSE_TEMP {
        get {
            return this.iNFUSE_TEMPField;
        }
        set {
            this.iNFUSE_TEMPField = value;
        }
    }

    /// <remarks/>
    public string DISPLAY_STEP_TEMP {
        get {
            return this.dISPLAY_STEP_TEMPField;
        }
        set {
            this.dISPLAY_STEP_TEMPField = value;
        }
    }

    /// <remarks/>
    public string DISPLAY_INFUSE_AMT {
        get {
            return this.dISPLAY_INFUSE_AMTField;
        }
        set {
            this.dISPLAY_INFUSE_AMTField = value;
        }
    }
}

