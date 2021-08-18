declare var $: any

class BankUserTransaction {

    static InitDataTables(): void {
        this.InitDataTablesChecking();
        this.InitDataTablesInvestment();
    }

    static InitDataTablesChecking(): void {
        $('#tblChecking').DataTable({
            "pageLength": 5,
            order: [3]
        });
    }

    static InitDataTablesInvestment(): void {
        $('#tblInvestment').DataTable({
            "pageLength": 5,
            order: [3]
        });
    }
}