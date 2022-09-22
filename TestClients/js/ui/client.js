async function createUser()
{
    const response = await fetch("https://localhost/identities", {
        method: 'POST',
        body: JSON.stringify({
            createTokenWithScopes: ["chat"]
        }),
        headers: {
            "content-type": "application/json"
        }
    });
    return await response.json();
}

async function createChatThread(token, topic)
{
    const response = await fetch("https://localhost/chat/threads", {
        method: 'POST',
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
