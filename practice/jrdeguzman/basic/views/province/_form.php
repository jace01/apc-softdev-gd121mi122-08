<?php

use yii\helpers\Html;
use yii\helpers\ArrayHelper;
use yii\widgets\ActiveForm;
use app\models\Region;

/* @var $this yii\web\View */
/* @var $model app\models\Province */
/* @var $form yii\widgets\ActiveForm */
?>

<div class="province-form">

    <?php $form = ActiveForm::begin(); ?>

    <?= $form->field($model, 'province_code')->textInput(['maxlength' => 32]) ?>

    <?= $form->field($model, 'province_description')->textInput(['maxlength' => 32]) ?>

    <?= $form->field($model, 'provincecol')->textInput(['maxlength' => 45]) ?>

    <?= $form->field($model, 'region_id')->dropdownList(
			ArrayHelper::map(Region::find()->all(), 'id', 'region_code'),
			['prompt'=>'Choose a region'])
			?>

    <div class="form-group">
        <?= Html::submitButton($model->isNewRecord ? 'Create' : 'Update', ['class' => $model->isNewRecord ? 'btn btn-success' : 'btn btn-primary']) ?>
    </div>

    <?php ActiveForm::end(); ?>

</div>
