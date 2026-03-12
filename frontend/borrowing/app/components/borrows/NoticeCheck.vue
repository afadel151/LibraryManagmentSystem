<script setup lang="ts">
defineProps<{
    title?: string,
    available?: Boolean
}>()
</script>

<template>
    <div class="text-xl">
        <p>Titre: <span class="font-bold">{{ title?.toUpperCase() }}</span></p>
    </div>
    <p v-if="!available" :class="`flex text-${available != undefined ? available ? 'success' : 'error' : 'base'} `">{{ available !=
        undefined ? available ? '' : 'Non Displonible' : ''}}
        <Icon :name="`lucide:${available != null ? available ? '' : 'info' : ''}`" size="24px" class="ml-2" />
    </p>
    <select v-if="available" class="select w-full">
        <option disabled selected>choisir un exemplaire</option>
        <option>1</option>
        <option>2</option>
    </select>
</template>