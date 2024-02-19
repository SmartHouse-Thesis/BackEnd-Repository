"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

// Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (senderName, message) {
    var li = document.createElement("li");
    var chatWindow = document.getElementById("chatWindow");
    chatWindow.appendChild(li);
    li.textContent = `${senderName}: ${message}`;
});

connection.on("ReceiveChatHistory", function (chatHistory) {
    chatHistory.forEach(function (log) {
        var li = document.createElement("li");
        var chatHistoryElement = document.getElementById("chatHistory");
        chatHistoryElement.appendChild(li);
        li.textContent = `${log.senderName}: ${log.message}`;
    });
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var senderId = document.getElementById("senderId").value;
    var receiverId = document.getElementById("receiverId").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", senderId, receiverId, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

document.getElementById("getHistoryButton").addEventListener("click", function (event) {
    var senderId = document.getElementById("senderId").value;
    var receiverId = document.getElementById("receiverId").value;
    connection.invoke("GetChatHistory", senderId, receiverId).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});