<script setup lang="ts">
defineProps<{
    name?: string,
    authorized?:Boolean
}>()
</script>


<template>

    <div class="text-xl">
        <p>Nom: <span class="font-bold">{{ name?.toUpperCase()    }}</span></p>
    </div>
    <p :class="`flex text-${authorized != undefined ? authorized ? 'success' : 'error' : 'base'} `">{{ authorized != undefined ? authorized ? 'Autorisee' : 'Non Autorisee' : ''}}
        <Icon :name="`lucide:${authorized != null ? authorized ? 'circle-check' : 'info' : ''}`" size="24px" class="ml-2" />
    </p>
    
</template>