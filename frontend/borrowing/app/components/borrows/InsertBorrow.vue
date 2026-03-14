<script setup lang="ts">
import MemberCheck from './MemberCheck.vue';
import NoticeCheck from './NoticeCheck.vue';

const today = new Date();

const day = String(today.getDate()).padStart(2, '0');
const month = String(today.getMonth() + 1).padStart(2, '0');
const year = today.getFullYear();

const insertModal = ref<HTMLDialogElement | null>(null)

const member_num = ref('')
const notice_num = ref('')

const exemplaire_num = ref(0)

const date_pret = ref(`${day}/${month}/${year}`)
const date_retour = ref('')

function checked_member(num: string,date_r: string) {
    member_num.value = num
    date_retour.value = date_r
}

function checked_notice(num: string) {
    notice_num.value = num
}
function selected_copy(exemplaire:number){
    exemplaire_num.value = exemplaire
}

async function insertBorrow(){
    
    insertModal.value?.close()
}
</script>

<template>

    <button class="btn btn-primary" @click="insertModal?.showModal()">
        <Icon name="lucide:circle-plus" size="24px" />
        Ajouter un pret
    </button>
    <dialog ref="insertModal" class="modal">
        <div class="modal-box">
            <h3 class="text-lg font-bold">Inserer un nouveau pret</h3>
            <div class="mt-4 space-y-2 flex  flex-col justify-center items-start">

                
                <MemberCheck @checked="checked_member" :date="date_pret" />
                
                <NoticeCheck class="w-full" @checked="checked_notice" @copy_selected="selected_copy" />

                <div class="text-lg w-full grid grid-cols-2 ">
                    <span> Date de pret : </span> <span class="font-bold">{{ date_pret }}</span>
                    <span>Date de retour: </span> <span class="font-bold" :class="date_retour != '' ? 'text-green-600' : ''">{{ date_retour == '' ? 'specifier l\'adherent' : date_retour }}</span>

                </div>
            </div>
            <div class="modal-action">

                <form method="dialog">
                    <button class="btn">
                        Fermer
                    </button>
                </form>

                <button @click="insertBorrow"  class="btn btn-primary " :disabled="member_num == '' || notice_num == '' || exemplaire_num != 0">
                    Inserer
                </button>
            </div>
        </div>

    </dialog>
</template>