class NotFoundError extends Error {
    constructor(message) {
        super(message);
        this.name = "Исключение, определенное пользователем";
    }
}

module.exports = NotFoundError;
