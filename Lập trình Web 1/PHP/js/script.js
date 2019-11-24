var maxIdProduct = 3

function formatCurrency(number) {
    var n = number.split('').reverse().join("");
    var n2 = n.replace(/\d\d\d(?!$)/g, "$&.");

    return n2.split('').reverse().join('') + " VND";
}

function saveProductInfo() {
    var product = { idProduct: 999999999, nameProduct: "None", priceProduct: 999999999 };

    product.idProduct = maxIdProduct;
    product.nameProduct = document.getElementById("iTenSanPham").value;
    product.priceProduct = +document.getElementById("iGiaSanPham").value;

    if (product.nameProduct == null || product.nameProduct == "" ||
        product.priceProduct == null || product.priceProduct == "") {
        return;
    }

    var moneyType = formatCurrency(product.priceProduct.toString());
    var actions = $("table td:last-child").html();
    var index = $("table tbody tr:last-child").index();
    var rows = "<th>" + maxIdProduct + "</th><td class=\"cTenSanPham\">" + product.nameProduct + "</td><td class=\"cGiaSanPham\">" + moneyType + "</td><td><button type=\"button\" class=\"btn btn-primary edit\" data-toggle=\"modal\" data-target=\"#exampleModal\">Chỉnh sửa</button>\n<button type=\"button\" class=\"btn btn-danger delete-row-tb\">Xóa</button></td>";
    var tbody = document.querySelector("tbody");
    var tr = document.createElement("tr");

    maxIdProduct += 1
    tr.innerHTML = rows;
    tbody.appendChild(tr)
}

function prepareModal() {
    document.getElementById("iMaSanPham").value = maxIdProduct.toString();
    document.getElementById("iTenSanPham").value = "";
    document.getElementById("iGiaSanPham").value = "";
    document.getElementById("exampleModalLabel").innerHTML = "Thêm sản phẩm";
    document.getElementById('iChinhSua').style.display = 'none';
    document.getElementById('iLuuThongTin').style.visibility = 'visible';
}

$(document).ready(function () {
    $(document).on("click", ".delete-row-tb", function () {
        $(this).parents("tr").remove();
    });
});

var $currentEditRow;

$(document).on("click", ".edit", function () {
    $currentEditRow = $(this).parents("tr");
    editProductModal($(this).parents("tr"));
});

function editProductModal(row) {
    document.getElementById('iChinhSua').style.display = 'block';
    document.getElementById('iLuuThongTin').style.visibility = 'hidden';
    document.getElementById("exampleModalLabel").innerHTML = "Chỉnh sửa sản phẩm";
    document.getElementById("iMaSanPham").value = $(row).find("th").text();
    document.getElementById("iTenSanPham").value = $(row).find(".cTenSanPham").text();
    document.getElementById("iGiaSanPham").value = parseInt($(row).find(".cGiaSanPham").text().replace(/\D/g, ''));
}

function update() {
    $currentEditRow.find("th").text(document.getElementById("iMaSanPham").value);
    $currentEditRow.find(".cTenSanPham").text(document.getElementById("iTenSanPham").value);
    $currentEditRow.find(".cGiaSanPham").text(formatCurrency(document.getElementById("iGiaSanPham").value));

    $('#exampleModal').modal('hide');
}