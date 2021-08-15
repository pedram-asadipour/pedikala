function SetReplyMessage(value, dist, replyName) {
    $(`#${dist}`).val(value);

    $("#replayMessage").html(`
                   <div class="col-6">
                        <p class="text- font-weight-bold" id="messageReply">پاسخ به نظر ${replyName}</p>
                    </div>
                    <div>
                        <button class="btn btn-sm btn-outline-dark" type="button" onclick='UnSetReplyMessage("${dist}")'>لغو</button>
                    </div>`);
}

function UnSetReplyMessage(dist) {
    $(`#${dist}`).val("");

    $("#replayMessage").html("");
}