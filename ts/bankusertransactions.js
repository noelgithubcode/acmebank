var BankUserTransaction = /** @class */ (function () {
    function BankUserTransaction() {
    }
    BankUserTransaction.InitDataTables = function () {
        this.InitDataTablesChecking();
        this.InitDataTablesInvestment();
    };
    BankUserTransaction.InitDataTablesChecking = function () {
        $('#tblChecking').DataTable({
            "pageLength": 5,
            order: [3]
        });
    };
    BankUserTransaction.InitDataTablesInvestment = function () {
        $('#tblInvestment').DataTable({
            "pageLength": 5,
            order: [3]
        });
    };
    return BankUserTransaction;
}());
//# sourceMappingURL=bankusertransactions.js.map