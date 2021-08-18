declare var $: any

class PeronContact {

    static InitDataTables(): void {
        $(document).ready(function () {
            $('#example').DataTable({
                responsive: true
            });
        });
    }
}