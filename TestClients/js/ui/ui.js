// todo: fetch and set token when selecting a different user
let currentToken;

async function initUi() {
    bindNewUser();
    bindNewChatThread();
    await renderUsers();
    await renderChatThreads();
}

async function renderUsers() {
    const usersSelect = document.getElementById("select-users");
    const { value } = await getUsers();

    usersSelect.textContent = null;
    for (const user of value) {
        const option = document.createElement("option");
        option.text = user.id;
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
        usersSelect.appendChild(option);
    }
}

async function renderChatThreads() {
    const usersSelect = document.getElementById("select-chatThreads");
    const { value } = await getChatThreads(currentToken);

    usersSelect.textContent = null;
    for (const chatThread of value) {
        const option = document.createElement("option");
        option.text = chatThread.id;
        usersSelect.appendChild(option);
    }
}

function bindNewChatThread() {
    const button = document.getElementById("btn-newChatThread");
    const input = document.getElementById("input-topic");
    button.onclick = async () => {
        const { chatThread } = await createChatThread(currentToken, input.value);
        const usersSelect = document.getElementById("select-chatThreads");
        const option = document.createElement("option");
        option.text = chatThread.id;
        usersSelect.appendChild(option);
    }
}