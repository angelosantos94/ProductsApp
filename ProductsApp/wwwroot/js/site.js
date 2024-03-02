$(document).ready(function () {
    var totalAmount = 0;
    var currentUrl = window.location.href;
    $("#searchProduct").on("focusout", function () {
        seartchProduct();
    });
    function seartchProduct()
    {
        // Your API endpoint URL
        var apiUrl = currentUrl+"api/Products/SearchProducts/";

        $.ajax({
            url: apiUrl + $('#searchProduct').val(),
            type: "GET",
            dataType: "json",
            success: function (data) {
                // Handle the successful response from the API
                console.log("API Response:", data);
                var responseObject = JSON.parse(JSON.stringify(data));
                console.log(responseObject.id);
                $("#ProductId").val(responseObject.id);
                $("#ProductName").val(responseObject.productName);
                $("#Cost").val(responseObject.cost);

            },
            error: function (xhr, status, error) {
                // Handle errors from the API call
                console.error("API Error:", status, error);
            }
        });
    }

    $("#searchButton").on("click", function () {
        seartchProduct();
    });

    $("#AddToCart").on("click", function () {
        // Create a new row with data (you can customize this part)
        var amount = parseFloat($("#Cost").val()) * parseFloat($("#Quantity").val());
        var button = $("<button>").text("Delete").attr("id", "deleteItem");
        var newRow = $("<tr>");
        var col1 = $("<td>").text($("#ProductId").val());
        var col2 = $("<td>").text($("#ProductName").val());
        var col3 = $("<td>").text($("#Cost").val());
        var col4 = $("<td>").text($("#Quantity").val());
        var col5 = $("<td>").text(amount).attr("id", "amount");
        var col6 = $("<td>").append(button);
        // Add more columns as needed

        // Append columns to the new row
        newRow.append(col1);
        newRow.append(col2);
        newRow.append(col3);
        newRow.append(col4);
        newRow.append(col5);
        newRow.append(col6);
        // Append more columns as needed

        // Append the new row to the table body
        $("#productTable tbody").append(newRow);
        totalAmount += amount;
        $("#totalAmount").val(totalAmount);
    });

    $("#productTable tbody").on("click", "#deleteItem", function () {
        // Find the closest row and remove it
        totalAmount -= $(this).closest("tr").find("#amount").text();
        $("#totalAmount").val(totalAmount);
        $(this).closest("tr").remove();
    });

    $("#cash").on("focusout", function () {
        // Get the value from textbox2
        var cash = parseFloat($(this).val());
        var amount = parseFloat($("#amount").val());
        // Perform any desired manipulation on the value (here, appending " Modified")
        var change = parseFloat($(this).val()) - parseFloat($("#totalAmount").val());

        // Set the new value for textbox1
        $("#Change").val(change);
    });

    function generate_uuidv4() {
        var dt = new Date().getTime();
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g,
            function (c) {
                var rnd = Math.random() * 16;//random number in range 0 to 16
                rnd = (dt + rnd) % 16 | 0;
                dt = Math.floor(dt / 16);
                return (c === 'x' ? rnd : (rnd & 0x3 | 0x8)).toString(16);
            }
        );

    }


    $("#saveTransaction").on("click", function () {
        var jsonData = [];

        // Generate a random UUID
        const transactionId = generate_uuidv4();
        // Iterate through each row in the table body
        $("#productTable tbody tr").each(function () {
            var row = {
                TransactionId: transactionId,
                ProductId: $(this).find("td:nth-child(1)").text(),
                Cost: $(this).find("td:nth-child(3)").text(),
                Quantity: $(this).find("td:nth-child(4)").text(),
                Amount: $(this).find("#amount").text(),
                TotalAmount: $("#totalAmount").val(),
                Cash: $("#cash").val(),
                Change: $("#Change").val()
            };

            jsonData.push(row);
        });

        // Display the JSON result
        console.log(JSON.stringify(jsonData));

        var apiUrl = currentUrl + "api/Transactions/SaveTransactions";

        $.ajax({
            url: apiUrl,
            type: "POST",
            contentType: "application/json",
            dataType: "text",
            data: JSON.stringify(jsonData),
            success: function (data) {
                // Handle the successful response from the API
                console.log("API Response:", data);
                $("#successModal").modal("show");

            },
            error: function (xhr, status, error) {
                console.error('API call failed:', status, error);
                if (xhr.status === 200) {
                    console.log('Unexpected HTML response:', xhr.responseText);
                }
            }
        });
    });
});