<script setup lang="ts">
const emit = defineEmits(['checked', 'failed'])


const loading = ref(false)
const title = ref('')
const available = ref(true)
const selected_copy = ref(0)
const notice_num = ref('')
const checked = ref(false)

const error_message = ref('Vous devez specifier la notice')

async function check() {
    if (notice_num.value == '') {
        error_message.value = 'Specifier le numero de la notice'
        return
    }
    loading.value = true;
    setTimeout(() => {
        loading.value = false;
        title.value = 'The brothers Karamazov'
        available.value = true
        checked.value = true
        if (selected_copy.value == 0) {
            error_message.value = 'Vous devez selectionner un exemplaire'
        }else{
            emit('checked',notice_num,selected_copy)
        }
    }, 2000)
}
</script>

<template>
    <div class="bg-blue- w-full">
        <label class="label">Numero de cote</label>
        <div class="flex justify-between w-full">
            <input class="input w-full" v-model="notice_num" />
            <button class="btn ml-2  w-32" @click="check">
                <Icon v-if="loading" name="lucide:loader-circle" size="24px" class="animate-spin" />
                <p>
                    Chercher
                </p>
            </button>
        </div>
    </div>
    <div v-if="checked" >

        <div class="text-xl">
            <p>Titre: <span class="font-bold">{{ title?.toUpperCase() }}</span></p>
        </div>
        <p v-if="!available" :class="`flex text-${available != undefined ? available ? 'success' : 'error' : 'base'} `">
            {{
                available !=
                    undefined ? available ? '' : 'Non Displonible' : '' }}
            <Icon :name="`lucide:${available != null ? available ? '' : 'info' : ''}`" size="24px" class="ml-2" />
        </p>
        <label class="label">Choisir un exemplaire</label>
        <select v-if="available" class="select w-full"  v-model="selected_copy">
            <option>1</option>
            <option>2</option>
        </select>
    </div>
    <div v-else>
         <p class="text-base-400 flex items-center ">
            <Icon name="lucide:message-square-warning" class="mr-2" size="20px" />
            {{ error_message }}
        </p>
    </div>
</template>