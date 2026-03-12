<script setup lang="ts">
interface Props {
  title?: string
  data?: string
  footer?: string
  indicator?: boolean
}
const props = withDefaults(defineProps<Props>(), {
  indicator: true
})

</script>
<template>  
    <div class="card bg-base-100 card-border ">
        <div class="card-body">
            <p class="text-base-content/60 text-md font-semibold uppercase ">{{ title }}</p>
            <div class=" flex items-end justify-between">
                <p class="text-2xl font-bold " >{{ data }}</p>
                <div v-if="footer" class=" flex items-center " :class="`text-${indicator ? 'success' : 'error'}`"> 
                    <Icon :name="`lucide:arrow-${indicator ? 'up' : 'down'}`" size="15px" />
                    {{ footer }}
                </div>
            </div>
        </div>
    </div>
</template>