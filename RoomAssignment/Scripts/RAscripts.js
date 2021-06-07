//send browser to new URL on selection of new floor
function doAction(val) {
    window.location = window.location.pathname + "?Floor=" + val;
}

//save selected floor value from dropdown box
$(function floorEdit() {
    $('#editFloor').change(function () {
        localStorage.setItem('todoDataFloor', this.value);
    });
    if (localStorage.getItem('todoDataFloor')) {
        $('#editFloor').val(localStorage.getItem('todoDataFloor'));
    }
});

//checks for local storage floor variable, if not found, sets it to default as Floor1
function checkForLocal() {
    if (typeof (localStorage.getItem('todoDataFloor')) === 'undefined' || localStorage.getItem('todoDataFloor') == null) {
        localStorage.setItem('todoDataFloor', '1');
    }
}

//if page loads with no floor querystring, function adds querystring to URL with current localstorage floor value
window.onload = function checkappendqs() {
    if (document.location.search.length == 0) {
        window.location = window.location.pathname + "?Floor=" + localStorage.getItem('todoDataFloor');
    }

    //call the page reload function to run every time the page reloads, using the stored refresh rate in ms
    var tempStorage = localStorage.getItem('todoDataRefresh');
    if (tempStorage != 0) {
        load(tempStorage);
    }
}

//display the day using moment.js
function timeByDay() {
    var update;
    (update = function () {
        document.getElementById("datetimetop")
        .innerHTML = moment().format('ddd MMM D, YYYY');
    })();
    setInterval(update, 1000);
}

//dynamically display time updating each second using moment.js
function timeBySec() {
    var update;
    (update = function () {
        document.getElementById("datetimebottom")
        .innerHTML = moment().format('h:mm:ss A');
    })();
    setInterval(update, 1000);
}

//Check the hour to display shift. 7am-7pm(1st) or 7pm-7am(2nd)
function checkTime() {
    var shift;
    (update = function () {
        var time = moment().format('H');

        if (time >= 7 && time < 19) {
            shift = "1st";
        }
        if ((time >= 19 && time < 24) || (time >= 0 && time < 7)) {
            shift = "2nd";
        }
        document.getElementById("displayShift")
        .innerHTML = shift;
    })();
    setInterval(update, 1000);
}

//save selected refresh value from dropdown box
$(function pageRefreshStore() {
    $('#pageRefresh').change(function () {
        localStorage.setItem('todoDataRefresh', this.value);
    });
    if (localStorage.getItem('todoDataRefresh')) {
        $('#pageRefresh').val(localStorage.getItem('todoDataRefresh'));
    }
});

//sets default refresh time, sets 5 mins as default for dropdown box if none has been selected
$(function defaultRefresh() {
    var temp = (localStorage.getItem('todoDataRefresh'));
    if (!temp && temp != 0) {
        localStorage.setItem('todoDataRefresh', 300000);
        $('#pageRefresh').val(localStorage.getItem('todoDataRefresh'));
    }
});

//reload page after set time from refresh dropdown
function load(sec) {
    if (sec != null) {
            setTimeout("window.open(self.location, '_self');", sec);
    }
}