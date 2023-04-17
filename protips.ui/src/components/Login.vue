<template>
    <div class="main-login">
        <div class="login">
            <div class="input-group mb-3">
                <input type="text" id="email" class="form-control" placeholder="meu-email" aria-label="Email" aria-describedby="addon-email" v-model="email" autocomplete="off">
                <span class="input-group-text" id="addon-email">@protips.com</span>
            </div>
            <div v-if="!showPassword" class="input-group mb-3">
                <input type="password" class="form-control" placeholder="Minha senha super secreta" aria-describedby="addon-password" v-model="password">
                <button id="addon-password" @click="showPassword = !showPassword"><font-awesome-icon icon="eye-slash" /></button>
            </div>
            <div v-else class="input-group mb-3">
                <input type="text" class="form-control" placeholder="Minha senha super secreta" aria-describedby="addon-password" v-model="password">
                <button id="addon-password" @click="showPassword = !showPassword"><font-awesome-icon icon="eye" /></button>
            </div>
            <button class="btn btn-primary btn-login" @click="login()" :disabled="loading">Login</button>
            <a href="#">Criar conta</a>
        </div>
    </div>

    <div class="toast-container position-fixed top-0 start-50 translate-middle-x p-3">
        <div id="liveToast" class="toast" role="alert" aria-live="assertive" aria-atomic="true">
            <div class="toast-header">
                <strong class="me-auto">Atenção</strong>
                <small>Agora</small>
                <button type="button" class="btn-close" data-bs-dismiss="toast" aria-label="Close"></button>
            </div>
            <div class="toast-body">
                {{toastMessage}}
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios';
import { Toast } from 'bootstrap/dist/js/bootstrap.esm.min';

export default {
    name: "Login",
    data() {
        return {
            token: undefined,
            email: undefined,
            password: undefined,
            showPassword: false,
            toastMessage: undefined,
            loading: false
        }
    },
    methods: {
        login() {
            const payload = {email: `${this.email}@protips.com`, password: this.password};
            const self = this;
            self.loading = true;

            axios
                .post('https://localhost:5001/api/v1/Login', payload)
                .then((response) => {
                    self.token = response.data.token;
                    self.loading = false;
                    self.toastMessage = `Seja bem vindo ${response.data.name}`;
                    self.showToast();
                })
                .catch(function (error) {
                    if(error.response.status === 500) {
                        self.toastMessage = error.response?.data?.Message;
                    }
                    else {
                        self.toastMessage = 'Ocorreu um ou mais erros de validação, tente novamente.';
                    }
                    self.showToast();

                    self.loading = false;
                });
        },
        showToast() {
            const toastLiveExample = document.getElementById('liveToast');
            const toastBootstrap = Toast.getOrCreateInstance(toastLiveExample);
            toastBootstrap.show();
        }
    }
}
</script>

<style scoped>
label {
    color: #26A69A;
}

::-webkit-input-placeholder { /* Edge */
    opacity: 0.2;
}

:-ms-input-placeholder { /* Internet Explorer 10-11 */
    opacity: 0.2;
}

::placeholder {
    opacity: 0.2;
}

.btn-login {
    width: 100%;
}

.main-login {
    width: 100vw;
    height: 100vh;
    display: flex;
    flex-direction: column;
    flex-wrap: wrap;
    align-content: center;
    justify-content: center;
    align-items: center;
    background-image: url("src/assets/imgs/background.jpg");
}

.login {
    background-color: #FFFFFF;
    width: 350px;
    height: 300px;
    display: flex;
    flex-direction: column;
    flex-wrap: wrap;
    align-content: center;
    justify-content: center;
    align-items: center;
    padding: 50px;
    border-radius: 10px;
}

</style>