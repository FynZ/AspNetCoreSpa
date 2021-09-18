<template>
    <button @click="login">Login</button>
</template>

<script>
export default {
  methods: {
    login() {
      this.$auth.loginWith('social');
    }
  }
}
</script>
