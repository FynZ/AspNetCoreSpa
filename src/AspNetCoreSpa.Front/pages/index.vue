<template>
  <main>
    <div v-if='$auth.loggedIn'>
      <figure class="bg-gray-100 rounded-xl p-8">
        <div class="mt-8 bg-white overflow-hidden shadow sm:rounded-lg p-6">
          <NuxtLink to="/login">
            Login
          </NuxtLink>
        </div>
      </figure>
    </div>
    <div v-else>You are {{ $auth.user }}</div>
    <Tutorial/>
  </main>
</template>

<script lang="ts">
import Vue from 'vue'

export default Vue.extend({})
</script>
