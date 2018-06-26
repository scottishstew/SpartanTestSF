
$('#lnkReset').click(function () {
    DoSearch("GetAll", "");
})


$('#lnkUnitNo').click(function () {

       //unit number button clicked, toggle active tab and show relevant page
    $('#hlUnitNo').addClass("tabLinkSelected");
    $('#hlItemNo').removeClass("tabLinkSelected");
    $('#hlItemNo').addClass("tabLink");
    $('#ItemNoTab').hide();
    $('#lnkUnitNo').addClass("tab_active");
    $('#lnkItemNo').removeClass("tab_active");
    $('#UnitNoTab').show();
})

$('#lnkItemNo').click(function () {
    //item number button clicked, toggle active tab and show relevant page
    $('#hlItemNo').addClass("tabLinkSelected");
    $('#hlUnitNo').removeClass("tabLinkSelected");
    $('#hlUnitNo').addClass("tabLink");
    $('#lnkItemNo').addClass("tab_active");
    $('#lnkUnitNo').removeClass("tab_active");
    $('#UnitNoTab').hide();
    $('#ItemNoTab').show();
})

$(document).ready(function ($) {
    //show unit number section by default
    $('#ItemNoTab').hide();
    $('#lnkUnitNo').addClass("tab_active");
    $('#hlUnitNo').addClass("tabLinkSelected");
    $('#hlItemNo').addClass("tabLink");

});

$('#btnSearchUnitNo').click(function () {
    //search via Unit Number
    var unitNoValue = $('#txtSearchUnitNo').val();
    DoSearch("UnitNo", unitNoValue);
})

$('#btnSearchItemNo').click(function () {
    //search via Item Number
    var itemNoValue = $('#txtSearchItemNo').val();
    DoSearch("ItemNo", itemNoValue);
})

function DoSearch(searchType, value) {

    if (searchType == "UnitNo") {
        //search by unit number web api URL
        var webAPIURL = '/api/WebAPI/GetEquipmentByUnitNo/' + value;
    }
    else if (searchType == "ItemNo") {
        //search by item number web api URL
        var webAPIURL = '/api/WebAPI/GetEquipmentByItemNo/' + value;
    }
    else {
        //get all equipment web api URL
        var webAPIURL = '/api/WebAPI/GetAllEquipment';
    }

    //ajax request to perform equipment search and return the relevant results
    $.ajax({
        type: 'GET',
        url: webAPIURL,
        dataType: 'json',
        success: function (data) {

            //populate table with returned equipment values
            $('#tblEquipmentItems').empty();

            $.each(data, function (index, equipmentItem) {
                //populate equipment table with new data when the request is completed
                PopulateTable(equipmentItem);
            });
        },
        failure: function () {
            //ajax request has failed, so inform the user
            alert('Failed to retrieve search results, please try again.');
        }

    });
}

function PopulateTable(equipmentItem) {
    //adding new row to equipment table
    $('#tblEquipmentItems').append("<tr><td><div class='eqItem'><img src='/Images/arrow.png' class='imgArrow' /><span class='txtUnitNo'>" + equipmentItem.ExternalId + "</span><br/> " + equipmentItem.EquipmentType.ExternalId + " <br />" + equipmentItem.EquipmentType.Description + " <br /><br /></div></td></tr>");

}
