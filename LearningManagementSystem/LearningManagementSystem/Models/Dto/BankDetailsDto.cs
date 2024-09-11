﻿namespace LearningManagementSystem.Models.Dto
{
    public class BankDetailsDto
    {
        public Guid Bank_Id { get; set; }
        public long AccountNo { get; set; }
        public string BankName { get; set; }
        public string AccountType { get; set; }
        public string IFSC_Code { get; set; }
        public string Branch { get; set; }
        public string State { get; set; }
    }
}
