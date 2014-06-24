/*

http://red-team-design.com/cool-notification-messages-with-css3-jquery/

http://red-team-design.com/wp-content/uploads/2011/07/cool-notification-messages-with-css3-and-jquery-demo.html#

*/


var myMessages = ['info','warning','error','success']; // define the messages types		 
function hideAllMessages()
{
    var messagesHeights = new Array(); // this array will store height for each
	 
    for (i=0; i<myMessages.length; i++)
    {
        messagesHeights[i] = $('.' + myMessages[i]).outerHeight();
        $('.' + myMessages[i]).css('top', -messagesHeights[i]); //move element outside viewport	  
    }
}

function showMessage1() {
    // Show message
    for (var i = 0; i < myMessages.length; i++) {
        showMessage(myMessages[i]);
    }
}


function showMessage(type)
{
    //$('.'+ type +'-trigger').click(function(){
    //    hideAllMessages();				  
    //    $('.'+type).animate({top:"0"}, 500);
    //});

    hideAllMessages();
        $('.' + type).animate({ top: "0" }, 500);
    
        setTimeout(function () {
            hideAllMessages();
        }, 5000);

 
}

$(document).ready(function(){
		 
    // Initially, hide them all
    hideAllMessages();
		 
    // Show message
    for(var i=0;i<myMessages.length;i++)
    {
        showMessage(myMessages[i]);
    }
		 
    // When message is clicked, hide it
    $('.message').click(function(){			  
        $(this).animate({top: -$(this).outerHeight()}, 500);
    });		 
		 
});       
