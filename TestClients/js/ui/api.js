async function createUser()
{
    const response = await fetch("https://localhost/identities", {
        method: "post",
        body: JSON.stringify({
            createTokenWithScopes: ["chat"]
        }),
        headers: {
            "content-type": "application/json"
        }
    });
    return await response.json();
}

async function getUserToken(identity)
{
    const response = await fetch(`https://localhost/identities/${identity}/:issueAccessToken`, {
        method: "post",
        body: JSON.stringify({
            scopes: ["chat"]
        }),
        headers: {
            "content-type": "application/json"
        }
    });
    return await response.json();
}

async function getUsers()
{
    const response = await fetch("https://localhost/identities");
    return await response.json();
}

async function createChatThread(token, topic)
{
    const response = await fetch("https://localhost/chat/threads", {
        method: "post",
        body: JSON.stringify({
            topic
        }),
        withCredentials: true,
        headers: {
            "authorization": `Bearer ${token}`,
            "content-type": "application/json"
        }
    });
    return response.json();
}

async function getChatThreads(token)
{
    const response = await fetch("https://localhost/chat/threads", {
        withCredentials: true,
        headers: {
            "authorization": `Bearer ${token}`
        }
    });
    return await response.json();
}
