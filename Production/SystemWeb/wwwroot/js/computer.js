$(document).ready(function () {
    var table = $('#datatable-buttons').DataTable({
        "ajax": {
            "url": "http://10.17.156.124/api/Computer",
            "method": "GET",
            "dataSrc": ""
        },
        "columns": [
            { "data": "Id", "title": "STT" },
            { "data": "CreateDate", "title": "Create Date" },
            {
                "data": "HostName",
                "title": "HostName",
                render: function (data, type, row) {

                    return '<button type="button" class="btn btn-outline-secondary waves-effect" data-bs-toggle="modal" data-bs-target=".bs-example-modal-xl" style ="width: 149px;" data-office="' + row.HostName + '"  onclick="handleClick(event)">' + data + '</button>'

                   /* return '<a href="#myModal" data-toggle="modal" data-target="#myModal" data-office="' + row.HostName + '" onclick="handleClick(event)">' + data + '</a>';*/
                }
            },
            { "data": "AddressIP", "title": "AddressIP" },            
            { "data": "Station", "title": "Station" },
            { "data": "UnitName", "title": "Unit Name" },
            { "data": "LineName", "title": "LineName" },
            { "data": "TypePC", "title": "TypePC" },           
            { "data": "Note", "title": "Note" }
        ],
        "scrollY": 650, 
        "paging": false,
        "initComplete": function () {
            // Thiết lập filter cho từng cột
            this.api().columns().every(function () {
                var column = this;
                var select = $('<select><option value=""></option></select>')
                    .appendTo($(column.footer()).empty())
                    .on('change', function () {
                        var val = $.fn.dataTable.util.escapeRegex(
                            $(this).val()
                        );

                        column
                            .search(val ? '^' + val + '$' : '', true, false)
                            .draw();
                    });

                column.data().unique().sort().each(function (d, j) {
                    select.append('<option value="' + d + '">' + d + '</option>')
                });
            });
        }
    });
 
    
});
function handleClick(event) {
    // Prevent the default behavior of the link (if needed)
    event.preventDefault();

    // Add your custom logic here
    // For example, you can get the data-office attribute value
    var office = event.target.getAttribute('data-office');

    // Log the office name (you can replace this with your logic)
    var table = $('#modal_table').DataTable();

    if (table) {
        table.destroy();
    }
    var table = $('#modal_table').DataTable({
        "ajax": {
            "url": "http://10.17.156.124/api/Software/"+office,
            "method": "GET",
            "dataSrc": ""
        },
        "columns": [
            { "data": "Id", "title": "STT" },
            { "data": "IP", "title": "IP" },
            { "data": "Name", "title": "Name" },
            { "data": "Publisher", "title": "Publisher" },
            { "data": "Version", "title": "Version" },
            { "data": "CreateTime", "title": "CreateTime" },
            { "data": "UpdateTime", "title": "UpdateTime" }
        ],
        "scrollY": 550,
        "paging": false 

    });
    updateDiskInfo(office);
}
function updateDiskInfo(hostname) {
    // Tạo đối tượng XMLHttpRequest
    var xhr = new XMLHttpRequest();

    // Đường dẫn API của bạn
    var url = "http://10.17.156.124/api/Software/disk/" + hostname;

    // Mở kết nối đến API với phương thức GET
    xhr.open("GET", url, true);

    // Xử lý khi nhận được phản hồi từ API
    xhr.onload = function () {
        if (xhr.status === 200) {
            // Parse dữ liệu từ JSON sang JavaScript object
            var response = JSON.parse(xhr.responseText);
            
            if (response && response.length > 0) {
               /* var ipAddress = response[0].IP;
                var hostName = response[0].HostName;*/
                var size = response[0].Size; 
                var diskUse = response[0].DiskUse; 
                var description = response[0].RemainingDiskSpaceDescription;

                // Cập nhật nội dung của các phần tử HTML
                /*document.getElementById("IP").textContent = ipAddress;
                document.getElementById("HostName").textContent = hostName;*/
                document.getElementById("Size").textContent = size+"GB";
                document.getElementById("DiskUse").textContent = diskUse +"GB";
                document.getElementById("Description").textContent = description +"GB";
            } 
        } else {
            // Xử lý khi có lỗi từ API
            console.error("Error fetching data:", xhr.status);
        }
    };

    // Xử lý khi có lỗi kết nối đến API
    xhr.onerror = function () {
        console.error("Request failed");
    };

    // Gửi yêu cầu đến API
    xhr.send();
}