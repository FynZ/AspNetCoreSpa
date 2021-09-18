<template>
  <main>
    <figure class="bg-gray-100 rounded-xl p-8">
      <img class="w-32 h-32 rounded-full mx-auto" src="/sarah-dayan.jpg" alt="" width="384" height="512">
        <div class="mt-8 bg-white overflow-hidden shadow sm:rounded-lg p-6">
          <NuxtLink to="/login">
            Login
          </NuxtLink>
      </div>
    </figure>
    <Tutorial/>
  </main>
</template>

<script lang="ts">
import Vue from 'vue'

export default Vue.extend({})
</script>
