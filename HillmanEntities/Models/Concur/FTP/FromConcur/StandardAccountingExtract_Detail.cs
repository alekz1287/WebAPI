using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HillmanGroup.API.Models.Concur.FTP
{
    /// <summary>
    /// A standard accounting extract should contain 1 or more "Details" rows that hold the actual
    /// expense data that needs to be inserted into the zTable in JDEdwards
    /// </summary>
    public class StandardAccountingExtract_Detail : StandardAccountingExtract_Section
    {
        private const int NUMBER_OF_COLUMNS = 400;

        public StandardAccountingExtract_Detail() : base(NUMBER_OF_COLUMNS)
        {

        }

        #region Batch Data
        [FtpField(1)]
        public string Constant { get; set; }
        [FtpField(2)]
        public string Batch_ID { get; set; }
        [FtpField(3)]
        public DateTime? Batch_Date { get; set; }
        [FtpField(4)]
        public int Sequence_Number { get; set; }
        #endregion

        #region Employee Data
        [FtpField(5)]
        public string Employee_ID { get; set; }
        [FtpField(6)]
        public string Employee_Last_Name { get; set; }
        [FtpField(7)]
        public string Employee_First_Name { get; set; }
        [FtpField(8)]
        public string Middle_Initial { get; set; }
        [FtpField(9)]
        public string Employee_Group_ID { get; set; }
        [FtpField(10)]
        public string Employee_Org_Unit_1 { get; set; }
        [FtpField(11)]
        public string Employee_Org_Unit_2 { get; set; }
        [FtpField(12)]
        public string Employee_Org_Unit_3 { get; set; }
        [FtpField(13)]
        public string Employee_Org_Unit_4 { get; set; }
        [FtpField(14)]
        public string Employee_Org_Unit_5 { get; set; }
        [FtpField(15)]
        public string Employee_Org_Unit_6 { get; set; }
        [FtpField(16)]
        public string ACH_Bank_Account_Number { get; set; }
        [FtpField(17)]
        public string ACH_Bank_Routing_Number { get; set; }
        [FtpField(18)]
        public decimal Journal_Net_of_Total_Adjusted_Reclaim_Tax { get; set; }
        #endregion

        #region Report Data
        [FtpField(19)]
        public string Report_ID { get; set; }
        [FtpField(20)]
        public string Report_Key { get; set; }
        [FtpField(21)]
        public string Ledger { get; set; }
        [FtpField(22)]
        public string Reimbursement_Currency_Alpha_ISE { get; set; }
        [FtpField(23)]
        public string Home_Country { get; set; }
        [FtpField(24)]
        public DateTime? Report_Submit_Date { get; set; }
        [FtpField(25)]
        public DateTime? Report_User_Defined_Date { get; set; }
        [FtpField(26)]
        public DateTime? Report_Payment_Processing_Date { get; set; }
        [FtpField(27)]
        public string Report_Name { get; set; }
        [FtpField(28)]
        public string Report_Image_Required { get; set; }
        [FtpField(29)]
        public string Report_has_VAT_entry { get; set; }
        [FtpField(30)]
        public string Report_has_TA_entry { get; set; }
        [FtpField(31)]
        public decimal Report_Total_Post_Amount { get; set; }
        [FtpField(32)]
        public decimal Report_Total_Approved_Amount { get; set; }
        [FtpField(33)]
        public string Report_Policy_Name { get; set; }
        [FtpField(34)]
        public string Report_Entry_Budget_Accrual_Date { get; set; }
        [FtpField(35)]
        public string Report_Org_Unit_1 { get; set; }
        [FtpField(36)]
        public string Report_Org_Unit_2 { get; set; }
        [FtpField(37)]
        public string Report_Org_Unit_3 { get; set; }
        [FtpField(38)]
        public string Report_Org_Unit_4 { get; set; }
        [FtpField(39)]
        public string Report_Org_Unit_5 { get; set; }
        [FtpField(40)]
        public string Report_Org_Unit_6 { get; set; }
        [FtpField(41)]
        public string Report_Custom_1 { get; set; }
        [FtpField(42)]
        public string Report_Custom_2 { get; set; }
        [FtpField(43)]
        public string Report_Custom_3 { get; set; }
        [FtpField(44)]
        public string Report_Custom_4 { get; set; }
        [FtpField(45)]
        public string Report_Custom_5 { get; set; }
        [FtpField(46)]
        public string Report_Custom_6 { get; set; }
        [FtpField(47)]
        public string Report_Custom_7 { get; set; }
        [FtpField(48)]
        public string Report_Custom_8 { get; set; }
        [FtpField(49)]
        public string Report_Custom_9 { get; set; }
        [FtpField(50)]
        public string Report_Custom_10 { get; set; }
        [FtpField(51)]
        public string Report_Custom_11 { get; set; }
        [FtpField(52)]
        public string Report_Custom_12 { get; set; }
        [FtpField(53)]
        public string Report_Custom_13 { get; set; }
        [FtpField(54)]
        public string Report_Custom_14 { get; set; }
        [FtpField(55)]
        public string Report_Custom_15 { get; set; }
        [FtpField(56)]
        public string Report_Custom_16 { get; set; }
        [FtpField(57)]
        public string Report_Custom_17 { get; set; }
        [FtpField(58)]
        public string Report_Custom_18 { get; set; }
        [FtpField(59)]
        public string Report_Custom_19 { get; set; }
        [FtpField(60)]
        public string Report_Custom_20 { get; set; }
        #endregion

        #region Report Entry Data
        [FtpField(61)]
        public string Report_Entry_Id { get; set; }
        [FtpField(62)]
        public string Report_Entry_Transaction_Type { get; set; }
        [FtpField(63)]
        public string Report_Entry_Expense_Type_Name { get; set; }
        [FtpField(64)]
        public DateTime? Report_Entry_Transaction_Date { get; set; }
        [FtpField(65)]
        public string Report_Entry_Currency_Alpha_Code { get; set; }
        [FtpField(66)]
        public decimal Report_Entry_Exchange_Rate { get; set; }
        [FtpField(67)]
        public string Report_Entry_Exchange_Rate_Direction { get; set; }
        [FtpField(68)]
        public bool Report_Entry_Is_Personal_Flag { get; set; }
        [FtpField(69)]
        public string Report_Entry_Description { get; set; }
        [FtpField(70)]
        public string Report_Entry_Vendor_Name { get; set; }
        [FtpField(71)]
        public string Report_Entry_Vendor_Description { get; set; }
        [FtpField(72)]
        public bool Report_Entry_Receipt_Received_Flag { get; set; }
        [FtpField(73)]
        public string Report_Entry_Receipt_Type { get; set; }
        [FtpField(74)]
        public int Total_Employee_Attendee { get; set; }
        [FtpField(75)]
        public int Total_Spouse_Attendee { get; set; }
        [FtpField(76)]
        public int Total_Business_Attendee { get; set; }
        [FtpField(77)]
        public string Report_Entry_Org_Unit_1 { get; set; }
        [FtpField(78)]
        public string Report_Entry_Org_Unit_2 { get; set; }
        [FtpField(79)]
        public string Report_Entry_Org_Unit_3 { get; set; }
        [FtpField(80)]
        public string Report_Entry_Org_Unit_4 { get; set; }
        [FtpField(81)]
        public string Report_Entry_Org_Unit_5 { get; set; }
        [FtpField(82)]
        public string Report_Entry_Org_Unit_6 { get; set; }
        [FtpField(83)]
        public string Report_Entry_Custom_1 { get; set; }   //Company Code
        [FtpField(84)]
        public string Report_Entry_Custom_2 { get; set; }   //Department
        [FtpField(85)]
        public string Report_Entry_Custom_3 { get; set; }   //Project
        [FtpField(86)]
        public string Report_Entry_Custom_4 { get; set; }
        [FtpField(87)]
        public string Report_Entry_Custom_5 { get; set; }
        [FtpField(88)]
        public string Report_Entry_Custom_6 { get; set; }
        [FtpField(89)]
        public string Report_Entry_Custom_7 { get; set; }
        [FtpField(90)]
        public string Report_Entry_Custom_8 { get; set; }
        [FtpField(91)]
        public string Report_Entry_Custom_9 { get; set; }
        [FtpField(92)]
        public string Report_Entry_Custom_10 { get; set; }
        [FtpField(93)]
        public string Report_Entry_Custom_11 { get; set; }
        [FtpField(94)]
        public string Report_Entry_Custom_12 { get; set; }
        [FtpField(95)]
        public string Report_Entry_Custom_13 { get; set; }
        [FtpField(96)]
        public string Report_Entry_Custom_14 { get; set; }
        [FtpField(97)]
        public string Report_Entry_Custom_15 { get; set; }
        [FtpField(98)]
        public string Report_Entry_Custom_16 { get; set; }
        [FtpField(99)]
        public string Report_Entry_Custom_17 { get; set; }
        [FtpField(100)]
        public string Report_Entry_Custom_18 { get; set; }
        [FtpField(101)]
        public string Report_Entry_Custom_19 { get; set; }
        [FtpField(102)]
        public string Report_Entry_Custom_20 { get; set; }
        [FtpField(103)]
        public string Report_Entry_Custom_21 { get; set; }
        [FtpField(104)]
        public string Report_Entry_Custom_22 { get; set; }
        [FtpField(105)]
        public string Report_Entry_Custom_23 { get; set; }
        [FtpField(106)]
        public string Report_Entry_Custom_24 { get; set; }
        [FtpField(107)]
        public string Report_Entry_Custom_25 { get; set; }
        [FtpField(108)]
        public string Report_Entry_Custom_26 { get; set; }
        [FtpField(109)]
        public string Report_Entry_Custom_27 { get; set; }
        [FtpField(110)]
        public string Report_Entry_Custom_28 { get; set; }
        [FtpField(111)]
        public string Report_Entry_Custom_29 { get; set; }
        [FtpField(112)]
        public string Report_Entry_Custom_30 { get; set; }
        [FtpField(113)]
        public string Report_Entry_Custom_31 { get; set; }
        [FtpField(114)]
        public string Report_Entry_Custom_32 { get; set; }
        [FtpField(115)]
        public string Report_Entry_Custom_33 { get; set; }
        [FtpField(116)]
        public string Report_Entry_Custom_34 { get; set; }
        [FtpField(117)]
        public string Report_Entry_Custom_35 { get; set; }
        [FtpField(118)]
        public string Report_Entry_Custom_36 { get; set; }
        [FtpField(119)]
        public string Report_Entry_Custom_37 { get; set; }
        [FtpField(120)]
        public string Report_Entry_Custom_38 { get; set; }
        [FtpField(121)]
        public string Report_Entry_Custom_39 { get; set; }
        [FtpField(122)]
        public string Report_Entry_Custom_40 { get; set; }
        [FtpField(123)]
        public decimal Report_Entry_Transaction_Amount { get; set; }
        [FtpField(124)]
        public decimal Report_Entry_Posted_Amount { get; set; }
        [FtpField(125)]
        public decimal Report_Entry_Approved_Amount { get; set; }
        [FtpField(126)]
        public string Payment_Type_Code { get; set; }
        [FtpField(127)]
        public string Payment_Code { get; set; }
        [FtpField(128)]
        public string Report_Payment_Reimbursement_Type { get; set; }
        #endregion

        #region Credit Card Data
        [FtpField(129)]
        public DateTime? Bill_Date { get; set; }
        [FtpField(130)]
        public string Billed_Credit_Card_Account_Number { get; set; }
        [FtpField(131)]
        public string Billed_Credit_Card_Description { get; set; }
        [FtpField(132)]
        public string Credit_Card_Transaction_JR_Key { get; set; }
        [FtpField(133)]
        public string Credit_Card_Transaction_Reference_Number { get; set; }
        [FtpField(134)]
        public string Credit_Card_Transaction_CCT_Key { get; set; }
        [FtpField(135)]
        public string Credit_Card_Transaction_CCT_Type { get; set; }
        [FtpField(136)]
        public string Credit_Card_Transaction_ID { get; set; }
        [FtpField(137)]
        public decimal Credit_Card_Transaction_Amount { get; set; }
        [FtpField(138)]
        public decimal Credit_Card_Transaction_Tax_Amount { get; set; }
        [FtpField(139)]
        public string Credit_Card_Transaction_Currency_Alpha_Code { get; set; }
        [FtpField(140)]
        public decimal Credit_Card_Transaction_Posted_Amount { get; set; }
        [FtpField(141)]
        public string Credit_Card_Transaction_Posted_Currency_Alpha_Code { get; set; }
        [FtpField(142)]
        public DateTime? Credit_Card_Transaction_Date { get; set; }
        [FtpField(143)]
        public DateTime? Credit_Card_Transaction_Posted_Date { get; set; }
        [FtpField(144)]
        public string Credit_Card_Transaction_Description { get; set; }
        [FtpField(145)]
        public string Credit_Card_Transaction_Master_Card_Code { get; set; }
        [FtpField(146)]
        public string Credit_Card_Transaction_Merchant_Name { get; set; }
        [FtpField(147)]
        public string Credit_Card_Transaction_Merchant_City { get; set; }
        [FtpField(148)]
        public string Credit_Card_Transaction_Merchant_State { get; set; }
        [FtpField(149)]
        public string Credit_Card_Transaction_Merchant_Country_Code { get; set; }
        [FtpField(150)]
        public string Credit_Card_Transaction_Merchant_Reference_Number { get; set; }
        [FtpField(151)]
        public string Credit_Card_Transaction_Billing_Type { get; set; }
        [FtpField(152)]
        public decimal Exchange_Rate_From_Billing_To_Employee_Currency { get; set; }
        [FtpField(153)]
        public decimal Billing_Amount { get; set; }
        [FtpField(154)]
        public string Individual_Credit_Card_Account_Number { get; set; }
        [FtpField(155)]
        public string Individual_Credit_Card_Name_On_Card { get; set; }
        [FtpField(156)]
        public string Merchant_Doing_Business_As { get; set; }
        [FtpField(157)]
        public string Acquirer_Reference_Number { get; set; }
        #endregion

        #region Entry Location Data
        [FtpField(158)]
        public string Report_Entry_Location_Country_Code { get; set; }
        [FtpField(159)]
        public string Report_Entry_Location_Country_Sub_Code { get; set; }
        [FtpField(160)]
        public string Report_Entry_Foreign_or_Domestic_Flag { get; set; }
        [FtpField(161)]
        public string Market_Code { get; set; }
        [FtpField(162)]
        public string Processor_Reference_Number { get; set; }
        #endregion

        #region Journal Entry Data
        [FtpField(163)]
        public string Journal_Payer_Payment_Type_Name { get; set; }
        [FtpField(164)]
        public string Journal_Payer_Payment_Code_Name { get; set; }
        [FtpField(165)]
        public string Journal_Payee_Payment_Type_Name { get; set; }
        [FtpField(166)]
        public string Journal_Payee_Payment_Code_Name { get; set; }
        [FtpField(167)]
        public string Journal_Account_Code { get; set; }
        [FtpField(168)]
        public string Journal_Debit_or_Credit { get; set; }
        [FtpField(169)]
        public decimal Journal_Amount { get; set; }
        [FtpField(170)]
        public string Journal_Key { get; set; }
        #endregion

        #region Car Mileage Data
        [FtpField(171)]
        public decimal Car_Business_Distance { get; set; }
        [FtpField(172)]
        public decimal Car_Personal_Distance { get; set; }
        [FtpField(173)]
        public int Car_Passenger_Count { get; set; }
        [FtpField(174)]
        public string Vehicle_ID { get; set; }
        [FtpField(175)]
        public decimal _Credit_Card_Transaction_Sales { get; set; }
        [FtpField(176)]
        public string Credit_Card_Vendor_Name { get; set; }
        [FtpField(177)]
        public decimal Cash_Advance_Request_Amount { get; set; }
        [FtpField(178)]
        public string Cash_Advance_Request_Currency_Alpha_Code { get; set; }
        [FtpField(179)]
        public string Cash_Advance_Request_Currency_Numeric_Code { get; set; }
        [FtpField(180)]
        public string Cash_Advance_Exchange_Rate { get; set; }
        [FtpField(181)]
        public string Cash_Advance_Currency_Alpha_Code { get; set; }
        [FtpField(182)]
        public string Cash_Advance_Currency_Numeric_Code { get; set; }
        [FtpField(183)]
        public DateTime? Cash_Advance_Issued_Date { get; set; }
        [FtpField(184)]
        public string Cash_Advance_Payment_Code_Name { get; set; }
        [FtpField(185)]
        public string Cash_Advance_Transaction_Type { get; set; }
        [FtpField(186)]
        public DateTime? Cash_Advance_Request_Date { get; set; }
        [FtpField(187)]
        public string Cash_Advance_Key { get; set; }
        [FtpField(188)]
        public string Cash_Advance_Payment_Method { get; set; }
        #endregion

        #region Allocation Data
        [FtpField(189)]
        public string Allocation_Key { get; set; }
        [FtpField(190)]
        public decimal Allocation_Percentage { get; set; }
        [FtpField(191)]
        public string Allocation_Custom_1 { get; set; } //Company Code
        [FtpField(192)]
        public string Allocation_Custom_2 { get; set; } //Department
        [FtpField(193)]
        public string Allocation_Custom_3 { get; set; } //Project
        [FtpField(194)]
        public string Allocation_Custom_4 { get; set; }
        [FtpField(195)]
        public string Allocation_Custom_5 { get; set; }
        [FtpField(196)]
        public string Allocation_Custom_6 { get; set; }
        [FtpField(197)]
        public string Allocation_Custom_7 { get; set; }
        [FtpField(198)]
        public string Allocation_Custom_8 { get; set; }
        [FtpField(199)]
        public string Allocation_Custom_9 { get; set; }
        [FtpField(200)]
        public string Allocation_Custom_10 { get; set; }
        [FtpField(201)]
        public string Allocation_Custom_11 { get; set; }
        [FtpField(202)]
        public string Allocation_Custom_12 { get; set; }
        [FtpField(203)]
        public string Allocation_Custom_13 { get; set; }
        [FtpField(204)]
        public string Allocation_Custom_14 { get; set; }
        [FtpField(205)]
        public string Allocation_Custom_15 { get; set; }
        [FtpField(206)]
        public string Allocation_Custom_16 { get; set; }
        [FtpField(207)]
        public string Allocation_Custom_17 { get; set; }
        [FtpField(208)]
        public string Allocation_Custom_18 { get; set; }
        [FtpField(209)]
        public string Allocation_Custom_19 { get; set; }
        [FtpField(210)]
        public string Allocation_Custom_20 { get; set; }
        [FtpField(211)]
        public decimal Journal_Net_of_Total_Adjusted_Tax { get; set; }
        #endregion

        #region Travel Allowance Data
        [FtpField(212)]
        public string TA_Reimb_Meal_Lodging_or_Combined_Type { get; set; }
        [FtpField(213)]
        public string TA_Display_Limit { get; set; }
        [FtpField(214)]
        public string TA_Allowance_Limit { get; set; }
        [FtpField(215)]
        public string Allowable_Threshold { get; set; }
        [FtpField(216)]
        public string TA_Fixed_Meal_Lodging_Type { get; set; }
        [FtpField(217)]
        public decimal Base_Amount { get; set; }
        [FtpField(218)]
        public decimal Allowance_Amount { get; set; }
        [FtpField(219)]
        public string TA_Fixed_Overnight { get; set; }
        [FtpField(220)]
        public string TA_Fixed_Breakfast_Provided_Flag { get; set; }
        [FtpField(221)]
        public string TA_Fixed_Lunch_Provided_Flag { get; set; }
        [FtpField(222)]
        public string TA_Fixed_Dinner_Provided_Flag { get; set; }
        [FtpField(223)]
        public decimal Total_Tax_Adjusted_Posted_Amount { get; set; }
        [FtpField(224)]
        public decimal Total_Reclaim_Adjusted_Amount { get; set; }
        #endregion

        #region VAT Tax Data
        [FtpField(225)]
        public string Tax_Authority_Name { get; set; }
        [FtpField(226)]
        public string Tax_Authority_Label { get; set; }
        [FtpField(227)]
        public decimal Report_Entry_Tax_Transaction_Amount { get; set; }
        [FtpField(228)]
        public decimal Report_Entry_Tax_Posted_Amount { get; set; }
        [FtpField(229)]
        public string Tax_Source { get; set; }
        [FtpField(230)]
        public decimal Report_Entry_Tax_Reclaim_Transaction_Amount { get; set; }
        [FtpField(231)]
        public decimal Report_Entry_Tax_Reclaim_Posted_Amount { get; set; }
        [FtpField(232)]
        public string Report_Entry_Tax_Code { get; set; }
        [FtpField(233)]
        public string Report_Entry_Tax_Reclaim_Domestic_Flag { get; set; }
        [FtpField(234)]
        public decimal Report_Entry_Tax_Adjusted_Amount { get; set; }
        [FtpField(235)]
        public decimal Report_Entry_Tax_Reclaim_Adjusted_Amount { get; set; }
        [FtpField(236)]
        public string Report_Entry_Tax_Reclaim_Code { get; set; }
        [FtpField(237)]
        public decimal Report_Entry_Tax_Reclaim_Trans_Adjusted_Amount { get; set; }
        [FtpField(238)]
        public string Report_Entry_Tax_Allocation_Reclaim_Code { get; set; }
        #endregion

        #region Assigned Travel Request Data
        [FtpField(239)]
        public string Travel_Request_ID { get; set; }
        [FtpField(240)]
        public string Travel_Request_Name { get; set; }
        [FtpField(241)]
        public decimal Travel_Request_Total_Posted_Amount { get; set; }
        [FtpField(242)]
        public decimal Travel_Request_Total_Approved_Amount { get; set; }
        [FtpField(243)]
        public DateTime? Travel_Request_Start_Date { get; set; }
        [FtpField(244)]
        public DateTime? Travel_Request_End_Date { get; set; }
        [FtpField(245)]
        public DateTime? Travel_Request_Authorized_Date { get; set; }
        #endregion

        #region VAT Tax Data2
        [FtpField(246)]
        public decimal Report_Entry_Total_Tax_Posted_Amount { get; set; }
        [FtpField(247)]
        public decimal Net_Tax_Amount { get; set; }
        [FtpField(248)]
        public decimal Report_Entry_Total_Reclaim_Adjusted_Amount { get; set; }
        [FtpField(249)]
        public decimal Net_Adjusted_Reclaim_Amount { get; set; }
        [FtpField(250)]
        public string Report_Entry_Payment_Type_Name { get; set; }
        #endregion

        #region Company Bill Statements
        [FtpField(251)]
        public string Card_Program_Type_Code { get; set; }
        [FtpField(252)]
        public DateTime? Statement_Period_Start_Date { get; set; }
        [FtpField(253)]
        public DateTime? Statement_Period_End_Date { get; set; }
        #endregion

        #region Expense Pay Data
        [FtpField(254)]
        public string Cash_Account_Code { get; set; }
        [FtpField(255)]
        public string Liability_Account_Code { get; set; }
        [FtpField(256)]
        public string Estimated_Payment_Date { get; set; }
        [FtpField(257)]
        public string Funding_Trace { get; set; }
        [FtpField(258)]
        public string Requested_Disbursement_Date { get; set; }
        [FtpField(259)]
        public string Cash_Advance_Name { get; set; }
        //[FtpField(260)]
        //public string Future_Use { get; set; }
        //[FtpField(261)]
        //public string Future_Use { get; set; }
        //[FtpField(262)]
        //public string Future_Use { get; set; }
        //[FtpField(263)]
        //public string Future_Use { get; set; }
        #endregion

        #region Employee Data
        [FtpField(264)]
        public string Employee_Login_ID { get; set; }
        [FtpField(265)]
        public string Employee_Email_Address { get; set; }
        [FtpField(266)]
        public string Employee_Custom_1 { get; set; }
        [FtpField(267)]
        public string Employee_Custom_2 { get; set; }
        [FtpField(268)]
        public string Employee_Custom_3 { get; set; }
        [FtpField(269)]
        public string Employee_Custom_4 { get; set; }
        [FtpField(270)]
        public string Employee_Custom_5 { get; set; }
        [FtpField(271)]
        public string Employee_Custom_6 { get; set; }
        [FtpField(272)]
        public string Employee_Custom_7 { get; set; }
        [FtpField(273)]
        public string Employee_Custom_8 { get; set; }
        [FtpField(274)]
        public string Employee_Custom_9 { get; set; }
        [FtpField(275)]
        public string Employee_Custom_10 { get; set; }
        [FtpField(276)]
        public string Employee_Custom_11 { get; set; }
        [FtpField(277)]
        public string Employee_Custom_12 { get; set; }
        [FtpField(278)]
        public string Employee_Custom_13 { get; set; }
        [FtpField(279)]
        public string Employee_Custom_14 { get; set; }
        [FtpField(280)]
        public string Employee_Custom_15 { get; set; }
        [FtpField(281)]
        public string Employee_Custom_16 { get; set; }
        [FtpField(282)]
        public string Employee_Custom_17 { get; set; }
        [FtpField(283)]
        public string Employee_Custom_18 { get; set; }
        [FtpField(284)]
        public string Employee_Custom_19 { get; set; }
        [FtpField(285)]
        public string Employee_Custom_20 { get; set; }
        //[FtpField(286)]
        //public string Future_Use { get; set; }
        //[FtpField(287)]
        //public string Future_Use { get; set; }
        //[FtpField(288)]
        //public string Future_Use { get; set; }
        //[FtpField(289)]
        //public string Future_Use { get; set; }
        //[FtpField(290)]
        //public string Future_Use { get; set; }
        #endregion

        #region Employee Banking Data
        [FtpField(291)]
        public bool Employee_Banking_Account_is_Active { get; set; }
        [FtpField(292)]
        public string Employee_Banking_Bank_Account_Type { get; set; }
        [FtpField(293)]
        public string Employee_Banking_Name_On_Account { get; set; }
        [FtpField(294)]
        public string Employee_Banking_Bank_Name { get; set; }
        [FtpField(295)]
        public string Employee_Banking_Bank_Branch_Location { get; set; }
        [FtpField(296)]
        public string Employee_Banking_Bank_Address_Line_1 { get; set; }
        [FtpField(297)]
        public string Employee_Banking_Bank_Address_Line_2 { get; set; }
        [FtpField(298)]
        public string Employee_Banking_Bank_City { get; set; }
        [FtpField(299)]
        public string Employee_Banking_Bank_Region { get; set; }
        [FtpField(300)]
        public string Employee_Banking_Bank_Postal_Code { get; set; }
        [FtpField(301)]
        public string Employee_Banking_Bank_Country_Code { get; set; }
        [FtpField(302)]
        public string Employee_Banking_Tax_ID { get; set; }
        [FtpField(303)]
        public string Employee_Banking_Is_Resident { get; set; }
        [FtpField(304)]
        public string Employee_Banking_Account_Status { get; set; }
        [FtpField(305)]
        public string Employee_Banking_Account_Currency { get; set; }
        //[FtpField(306)]
        //public string Future_Use { get; set; }
        //[FtpField(307)]
        //public string Future_Use { get; set; }
        //[FtpField(308)]
        //public string Future_Use { get; set; }
        //[FtpField(309)]
        //public string Future_Use { get; set; }
        //[FtpField(310)]
        //public string Future_Use { get; set; }
        #endregion

        #region Report Data
        [FtpField(311)]
        public decimal Personal_Expenses { get; set; }
        [FtpField(312)]
        public decimal Total_Amount_Claimed { get; set; }
        [FtpField(313)]
        public decimal Amount_Due_Employee { get; set; }
        [FtpField(314)]
        public decimal Amount_Due_Company_Card { get; set; }
        [FtpField(315)]
        public decimal Amount_Not_Approved { get; set; }
        [FtpField(316)]
        public decimal Amount_Company_Paid { get; set; }
        [FtpField(317)]
        public decimal Amount_Due_Company { get; set; }
        [FtpField(318)]
        public decimal Payment_Confirmed_Amount { get; set; }
        [FtpField(319)]
        public decimal Amount_Due_Employee_2 { get; set; }
        [FtpField(320)]
        public decimal Amount_Due_Company_Card_2 { get; set; }
        [FtpField(321)]
        public string Report_Type { get; set; }
        [FtpField(322)]
        public decimal Total_Tax_Adjusted_Amount { get; set; }
        [FtpField(323)]
        public decimal Net_Adjusted_Tax_Amount { get; set; }
        [FtpField(324)]
        public DateTime? Report_Start_Date { get; set; }
        [FtpField(325)]
        public DateTime? Report_End_Date { get; set; }
        //[FtpField(326)]
        //public string Future_Use { get; set; }
        #endregion

        #region Cash Advance Data
        [FtpField(327)]
        public decimal Cash_Advance_Returns_Amount { get; set; }
        [FtpField(328)]
        public string Cash_Advance_Return_Received { get; set; }
        [FtpField(329)]
        public decimal Cash_Advance_Utilized_Amount { get; set; }
        //[FtpField(330)]
        //public string Future_Use { get; set; }
        //[FtpField(331)]
        //public string Future_Use { get; set; }
        //[FtpField(332)]
        //public string Future_Use { get; set; }
        //[FtpField(333)]
        //public string Future_Use { get; set; }
        #endregion

        #region Report Entry Data
        [FtpField(334)]
        public string Report_Entry_Location_City_Name { get; set; }
        [FtpField(335)]
        public bool Is_Billable { get; set; }
        [FtpField(336)]
        public string Report_Entry_From_Location { get; set; }
        [FtpField(337)]
        public string Report_Entry_To_Location { get; set; }
        [FtpField(338)]
        public string Report_Entry_Location_Name { get; set; }
        [FtpField(339)]
        public string Country { get; set; }
        [FtpField(340)]
        public string State_Province { get; set; }
        [FtpField(341)]
        public string UUID { get; set; }
        [FtpField(342)]
        public string Supplier_Tax_ID { get; set; }
        //[FtpField(343)]
        //public string Future_Use { get; set; }
        //[FtpField(344)]
        //public string Future_Use { get; set; }
        //[FtpField(345)]
        //public string Future_Use { get; set; }
        //[FtpField(346)]
        //public string Future_Use { get; set; }
        #endregion

        #region VAT Tax Data 3
        [FtpField(347)]
        public decimal Allocation_Total_Tax_Transaction_Amount { get; set; }
        [FtpField(348)]
        public decimal Allocation_Total_Tax_Posted_Amount { get; set; }
        [FtpField(349)]
        public decimal Allocation_Total_Tax_Reclaim_Transaction_Amount { get; set; }
        [FtpField(350)]
        public decimal Allocation_Total_Tax_Reclaim_Posted_Amount { get; set; }
        [FtpField(351)]
        public decimal Allocation_Total_Tax_Reclaim_Transaction_Adjusted_Amount { get; set; }
        [FtpField(352)]
        public string Merchant_Tax_ID { get; set; }
        //[FtpField(353)]
        //public string Future_Use { get; set; }
        //[FtpField(354)]
        //public string Future_Use { get; set; }
        //[FtpField(355)]
        //public string Future_Use { get; set; }
        //[FtpField(356)]
        //public string Future_Use { get; set; }
        #endregion

        #region Request Data
        [FtpField(357)]
        public string Request_Name { get; set; }
        [FtpField(358)]
        public decimal Total_Posted_Amount { get; set; }
        [FtpField(359)]
        public decimal Total_Approved_Amount { get; set; }
        [FtpField(360)]
        public DateTime? Start_Date { get; set; }
        [FtpField(361)]
        public DateTime? End_Date { get; set; }
        [FtpField(362)]
        public DateTime? Authorized_Date { get; set; }
        [FtpField(363)]
        public string Authorization_Request_ID { get; set; }
        #endregion


    }
}
