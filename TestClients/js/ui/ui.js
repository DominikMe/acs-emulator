// todo: fetch and set token when selecting a different user
let currentToken;
let currentUser;
let chatAdapter;

async function initUi() {
    bindNewUser();
    bindNewChatThread();
    bindSelectUser();
    bindSelectChatThread();
    await renderUsers();
}

async function renderUsers() {
    const usersSelect = document.getElementById("select-users");
    const { value } = await getUsers();

    for (const user of value) {
        const option = document.createElement("option");
        option.text = user.id;
        option.value = user.id;
        usersSelect.appendChild(option);
    }
}

function bindNewUser() {
    const button = document.getElementById("btn-newUser");
    button.onclick = async () => {
        const { identity } = await createUser();
        const usersSelect = document.getElementById("select-users");
        const option = document.createElement("option");
        option.text = identity.id;
        option.value = identity.id;
        usersSelect.appendChild(option);
    }
}

function bindSelectUser() {
    const usersSelect = document.getElementById("select-users");
    usersSelect.onchange = async () => {
        const identity = usersSelect.selectedOptions[0].value;
        if (!identity) return;
        usersSelect.disabled = true;
        document.getElementById("btn-newUser").disabled = true;
        const { token } = await getUserToken(identity);
        currentToken = token;
        currentUser = identity;
        const chatThreadsDiv = document.getElementById("chatThreads");
        chatThreadsDiv.style = "visibility: visible";
        await renderChatThreads();
    }
}

function bindNewChatThread() {
    const button = document.getElementById("btn-newChatThread");
    const input = document.getElementById("input-topic");
    button.onclick = async () => {
        const { chatThread } = await createChatThread(currentToken, input.value);
        const usersSelect = document.getElementById("select-chatThread");
        const option = document.createElement("option");
        option.text = chatThread.id;
        option.value = chatThread.id;
        usersSelect.appendChild(option);
    }
}

function bindSelectChatThread() {
    const threadSelect = document.getElementById("select-chatThread");
    threadSelect.onchange = async () => {
        const threadId = threadSelect.selectedOptions[0].value;
        if (!threadId) return;
        threadSelect.disabled = true;
        document.getElementById("btn-newChatThread").disabled = true;
        document.getElementById("input-topic").disabled = true;
        chatAdapter = await chatComposite.loadChatComposite({
            displayName: "Emil the Emulator",
            threadId,
            userId: currentUser,
            endpoint: "https://localhost/",
            token: currentToken
        },
        document.getElementById('chat-container'));
    }
}

async function renderChatThreads() {
    const usersSelect = document.getElementById("select-chatThread");
    const { value } = await getChatThreads(currentToken);

    for (const chatThread of value) {
        const option = document.createElement("option");
        option.text = chatThread.id;
        option.value = chatThread.id;
        usersSelect.appendChild(option);
    }
}
