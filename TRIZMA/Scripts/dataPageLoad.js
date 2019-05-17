
                function GetPlayers() {
                    $.ajax({
                        url: '/ddlPopulate/GetPlayers',
                        type: "POST",
                        dataType: "JSON",
                        success: function (list) {
                            $("#datatable-checkbox tbody > tr").remove(); // clear before appending new list
                            $.each(list, function(i) {
                                $("#datatable-checkbox tbody").append(
                                     "<tr>" +
                                         "<td><th><input type=checkbox id=check-all class=flat></th></td>" +
                                         "<td>" + list[i].ID + "</td>" +
                                         "<td>" + list[i].Name + "</td>" +
                                         "<td>" + list[i].Desc + "</td>" +
                                         "<td>" + list[i].Country + "</td>" +
                                         "<td>" + list[i].Created + "</td>" +
                                         "<td>" + list[i].Edited + "</td>" +
                                     "</tr>");
                            })
                        }//Fermeture Success
                    });
                }

