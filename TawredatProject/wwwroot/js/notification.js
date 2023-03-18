
var connectionNotification = new signalR.HubConnectionBuilder()
    .withUrl("/hubs/notification").build();

document.getElementById("sendButton").disabled = true;

connectionNotification.on("LoadNotification", function (message, counter) {
    document.getElementById("messageList").innerHTML = "";
    var notificationCounter = document.getElementById("notificationCounter");
    notificationCounter.innerHTML = "<span>(" + counter + ")</span>";
    for (let i = message.length - 1; i >= 0; i--) {
        var li = document.createElement("li");
        var li2 = document.createElement("li");
        var li3 = document.createElement("li");
        var li4 = document.createElement("li");
        li.textContent = "Notification - " + message[i].mesage;
        li2.textContent = message[i].id;
       
       
        const lineBreak = document.createElement('br');
        document.getElementById("messageList").appendChild(li);
        document.getElementById("messageList").appendChild(lineBreak);
        document.getElementById("messageList").appendChild(lineBreak);
       
       
        li.addEventListener('click', () => {
            var arr = [];
          
            var arr = [li2.textContent];
            
          
            $.ajax({
                type: "POST",
                url: "/Admin/Home/RealTimeNotification",
                data: ({ Ids: arr, OnlyActive: true }),
                contextType: "application/json; charset=utf-8",
                datatype: "json",
                traditional: true,
                success: OnSuccessResult,
                error: OnError
            });
         
            function OnSuccessResult(data) {
                if (data.type === 'شكوي من عميل') {
                   
                    window.location.href = "/Admin/Complains/Form2?id=" + data.id;

                }
                else
                {
                   
                    window.location.href = "/Admin/ContactUs/Form2?id=" + data.id;

                }
              

            }
          
            function OnError(data) {

            }



        }
            




        );
      
    }
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var message = document.getElementById("notificationInput").value;
    connectionNotification.send("SendMessage", message).then(function () {
        document.getElementById("notificationInput").value = "";
    });
    event.preventDefault();
});


connectionNotification.start().then(function () {
    connectionNotification.send("LoadMessages")
    document.getElementById("sendButton").disabled = false;
});
